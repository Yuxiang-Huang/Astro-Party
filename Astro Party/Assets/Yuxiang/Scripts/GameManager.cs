using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<List<GameObject>> ships;
    public List<List<GameObject>> inGameShips;
    List<Vector3> pos;
    List<Vector3> rot;

    ScoreManager scoreManagerScript;

    public GameObject nextButton;

    public GameObject P1ShipPlayer;
    public GameObject P1ShipBot;
    public GameObject P1TextPlayer;
    public GameObject P1TextBot;
    public GameObject P1TextOff;
    public int P1Team = 0;
    public GameObject P1TeamButtonObject;
    public GameObject P1SetRotateButton;
    public GameObject P1SetShootButton;

    public GameObject P2ShipPlayer;
    public GameObject P2ShipBot;
    public GameObject P2TextPlayer;
    public GameObject P2TextBot;
    public GameObject P2TextOff;
    public int P2Team = 1;
    public GameObject P2TeamButtonObject;
    public GameObject P2SetRotateButton;
    public GameObject P2SetShootButton;

    public GameObject P3ShipPlayer;
    public GameObject P3ShipBot;
    public GameObject P3TextPlayer;
    public GameObject P3TextBot;
    public GameObject P3TextOff;
    public int P3Team = 2;
    public GameObject P3TeamButtonObject;
    public GameObject P3SetRotateButton;
    public GameObject P3SetShootButton;

    public GameObject P4ShipPlayer;
    public GameObject P4ShipBot;
    public GameObject P4TextPlayer;
    public GameObject P4TextBot;
    public GameObject P4TextOff;
    public int P4Team = 3;
    public GameObject P4TeamButtonObject;
    public GameObject P4SetRotateButton;
    public GameObject P4SetShootButton;

    public int spawnX = 850;
    public int spawnZ = 400;
    bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
        pos = new List<Vector3>() { new Vector3(spawnX, 10, spawnZ), new Vector3(-spawnX, 10, spawnZ),
        new Vector3(spawnX, 10, -spawnZ), new Vector3(-spawnX, 10, -spawnZ)};
        rot = new List<Vector3>() {new Vector3(0, 180, 0), new Vector3(0, 90, 0),
        new Vector3(0, -90, 0), new Vector3(0, 0, 0)};

        ships = new List<List<GameObject>>();
        ships.Add(new List<GameObject>());
        ships.Add(new List<GameObject>());
        ships.Add(new List<GameObject>());
        ships.Add(new List<GameObject>());

        inGameShips = new List<List<GameObject>>();
        inGameShips.Add(new List<GameObject>());
        inGameShips.Add(new List<GameObject>());
        inGameShips.Add(new List<GameObject>());
        inGameShips.Add(new List<GameObject>());

        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (List<GameObject> shipList in inGameShips)
        //{
        //    foreach (GameObject ship in shipList)
        //    {
        //        Debug.Log(ship);
        //    }
        //}

        //choosing team
        int activeTeam = 0;
        foreach (List<GameObject> ship in ships)
        {
            if (ship.Count > 0)
            {
                activeTeam++;
            }
        }
        if (activeTeam >= 2)
        { 
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }

        //removing killed ships and pilots in game
        foreach (List<GameObject> ship in inGameShips)
        {
            for (int i = ship.Count - 1; i >= 0; i--)
            {
                if (ship[i] == null)
                {
                    ship.RemoveAt(i);
                }
            }
        }

        //check for ending round
        if (gameStarted)
        {
            int activeTeamInGame = 0;
            foreach (List<GameObject> ship in inGameShips)
            {
                if (ship.Count > 0)
                {
                    activeTeamInGame++;
                }
            }

            if (activeTeamInGame <= 1)
            {
                StartCoroutine("endRound");
                gameStarted = false;
            }
        }  
    }

    public void spawnShips()
    {
        gameStarted = true;

        for (int i = 0; i < ships.Count; i++)
        {
            for (int j = 0; j < ships[i].Count; j++)
            {
                //spawn one ship
                int ran = Random.Range(0, pos.Count);
                inGameShips[i].Add(Instantiate(ships[i][j], pos[ran], ships[i][j].transform.rotation));
                inGameShips[i][j].transform.Rotate(rot[ran]);

                inGameShips[i][j].GetComponent<MutualShip>().team = i;

                pos.RemoveAt(ran);
                rot.RemoveAt(ran);
            }
        }

        pos = new List<Vector3>() { new Vector3(spawnX, 10, spawnZ), new Vector3(-spawnX, 10, spawnZ),
        new Vector3(spawnX, 10, -spawnZ), new Vector3(-spawnX, 10, -spawnZ)};
        rot = new List<Vector3>() {new Vector3(0, 180, 0), new Vector3(0, 90, 0),
        new Vector3(0, -90, 0), new Vector3(0, 0, 0)};
    }

    public void P1Button()
    {
        buttonHelper(P1ShipPlayer, P1ShipBot, P1TextPlayer, P1TextBot, P1TextOff, P1Team, P1TeamButtonObject,
            P1SetRotateButton, P1SetShootButton, scoreManagerScript.P1);
    }

    public void P2Button()
    {
        buttonHelper(P2ShipPlayer, P2ShipBot, P2TextPlayer, P2TextBot, P2TextOff, P2Team, P2TeamButtonObject,
            P2SetRotateButton, P2SetShootButton, scoreManagerScript.P2);
    }

    public void P3Button()
    {
        buttonHelper(P3ShipPlayer, P3ShipBot, P3TextPlayer, P3TextBot, P3TextOff, P3Team, P3TeamButtonObject,
            P3SetRotateButton, P3SetShootButton, scoreManagerScript.P3);
    }

    public void P4Button()
    {
        buttonHelper(P4ShipPlayer, P4ShipBot, P4TextPlayer, P4TextBot, P4TextOff, P4Team, P4TeamButtonObject,
            P4SetRotateButton, P4SetShootButton, scoreManagerScript.P4);
    }

    void buttonHelper(GameObject player, GameObject bot, GameObject textPlayer, GameObject textBot, GameObject textOff,
        int team, GameObject teamButton, GameObject setRotateButton, GameObject setShootButton, GameObject picture)
    {
        List<GameObject> ship = ships[team];
        if (ship.Contains(player))
        {
            textPlayer.SetActive(false);
            textBot.SetActive(true);
            ship.Remove(player);
            ship.Add(bot);

            setRotateButton.SetActive(false);
            setShootButton.SetActive(false);
        }
        else if (ship.Contains(bot))
        {
            textBot.SetActive(false);
            textOff.SetActive(true);
            ship.Remove(bot);

            teamButton.SetActive(false);
            teamButton.SetActive(false);
            picture.SetActive(true);
        }
        else
        {
            textOff.SetActive(false);
            textPlayer.SetActive(true);
            ship.Add(player);

            setRotateButton.SetActive(true);
            setShootButton.SetActive(true);
            teamButton.SetActive(true);
            teamButton.SetActive(true);
            picture.SetActive(true);
        }
    }

    public void P1TeamButton()
    {
        GameObject curr = findShip(P1Team, P1ShipPlayer, P1ShipBot);
        
        ships[P1Team].Remove(curr);
        P1Team++;

        if (P1Team == 4)
        {
            P1Team = 0;
        }
        ships[P1Team].Add(curr);
    }

    public void P2TeamButton()
    {
        GameObject curr = findShip(P2Team, P2ShipPlayer, P2ShipBot);

        ships[P2Team].Remove(curr);
        P2Team++;

        if (P2Team == 4)
        {
            P2Team = 0;
        }
        ships[P2Team].Add(curr);
        
    }

    public void P3TeamButton()
    {
        GameObject curr = findShip(P3Team, P3ShipPlayer, P3ShipBot);
        
        ships[P3Team].Remove(curr);
        P3Team++;
        if (P3Team == 4)
        {
            P3Team = 0;
        }
        ships[P3Team].Add(curr);
    }

    public void P4TeamButton()
    {
        GameObject curr = findShip(P4Team, P4ShipPlayer, P4ShipBot);
     
        ships[P4Team].Remove(curr);
        P4Team++;
        if (P4Team == 4)
        {
            P4Team = 0;
        }
        ships[P4Team].Add(curr);   
    }

    GameObject findShip(int team, GameObject shipTarget, GameObject bot)
    {
        GameObject ans = null;
        List<GameObject> ship = ships[team];
        if (ship.Contains(shipTarget))
        {
            ans = shipTarget;
        }
        else if (ship.Contains(bot))
        {
            ans = bot;
        }
        return ans;
    }

    IEnumerator endRound()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < inGameShips.Count; i++)
        {
            List<GameObject> shipList = inGameShips[i];

            if (scoreManagerScript.gameMode == "team")
            {
                if (shipList.Count > 0)
                {
                    foreach (GameObject ship in ships[i])
                    {
                        int id = ship.GetComponent<MutualShip>().id;

                        switch (id)
                        {
                            case 1:
                                scoreManagerScript.P1Score++;
                                break;
                            case 2:
                                scoreManagerScript.P2Score++;
                                break;
                            case 3:
                                scoreManagerScript.P3Score++;
                                break;
                            case 4:
                                scoreManagerScript.P4Score++;
                                break;
                        }
                    }
                }
            }

            while (shipList.Count > 0)
            {
                Destroy(shipList[0]);
                shipList.RemoveAt(0);
            }

        }

        scoreManagerScript.StartCoroutine("scoreUpdate");
    }
}
