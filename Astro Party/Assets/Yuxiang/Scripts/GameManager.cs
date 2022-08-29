using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<List<GameObject>> ships;
    public List<List<GameObject>> inGameShips;
    List<Vector3> pos;
    List<Vector3> rot;

    public GameObject endScreen;

    public GameObject nextButton;
    //public GameObject P1WonText;
    //public GameObject P2WonText;
    //public GameObject P3WonText;
    //public GameObject P4WonText;
    //public GameObject BotWonText;
    //public GameObject DrawText;

    public GameObject P1ShipPlayer;
    public GameObject P1ShipBot;
    public GameObject P1TextPlayer;
    public GameObject P1TextBot;
    public GameObject P1TextOff;
    int P1Team = 0;

    public GameObject P2ShipPlayer;
    public GameObject P2ShipBot;
    public GameObject P2TextPlayer;
    public GameObject P2TextBot;
    public GameObject P2TextOff;
    int P2Team = 1;

    public GameObject P3ShipPlayer;
    public GameObject P3ShipBot;
    public GameObject P3TextPlayer;
    public GameObject P3TextBot;
    public GameObject P3TextOff;
    int P3Team = 2;

    public GameObject P4ShipPlayer;
    public GameObject P4ShipBot;
    public GameObject P4TextPlayer;
    public GameObject P4TextBot;
    public GameObject P4TextOff;
    int P4Team = 3;

    int spawnX = 850;
    int spawnZ = 400;
    bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
        pos = new List<Vector3>() { new Vector3(spawnX, 30, spawnZ), new Vector3(-spawnX, 30, spawnZ),
        new Vector3(spawnX, 30, -spawnZ), new Vector3(-spawnX, 30, -spawnZ)};
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

        //in game
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
                int ran = Random.Range(0, pos.Count);
                inGameShips[i].Add(Instantiate(ships[i][j], pos[ran], ships[i][j].transform.rotation));
                inGameShips[i][j].transform.Rotate(rot[ran]);
                pos.RemoveAt(ran);
                rot.RemoveAt(ran);
            }
        }

        pos = new List<Vector3>() { new Vector3(spawnX, 30, spawnZ), new Vector3(-spawnX, 30, spawnZ),
        new Vector3(spawnX, 30, -spawnZ), new Vector3(-spawnX, 30, -spawnZ)};
        rot = new List<Vector3>() {new Vector3(0, 180, 0), new Vector3(0, 90, 0),
        new Vector3(0, -90, 0), new Vector3(0, 0, 0)};
    }

    public void P1Button()
    {
        buttonHelper(P1ShipPlayer, P1ShipBot, P1TextPlayer, P1TextBot, P1TextOff, P1Team);
    }

    public void P2Button()
    {
        buttonHelper(P2ShipPlayer, P2ShipBot, P2TextPlayer, P2TextBot, P2TextOff, P2Team);
    }

    public void P3Button()
    {
        buttonHelper(P3ShipPlayer, P3ShipBot, P3TextPlayer, P3TextBot, P3TextOff, P3Team);
    }

    public void P4Button()
    {
        buttonHelper(P4ShipPlayer, P4ShipBot, P4TextPlayer, P4TextBot, P4TextOff, P4Team);
    }

    void buttonHelper(GameObject player, GameObject bot, GameObject textPlayer, GameObject textBot, GameObject textOff, int team)
    {
        List<GameObject> ship = ships[team];
        if (ship.Contains(player))
        {
            textPlayer.SetActive(false);
            textBot.SetActive(true);
            ship.Remove(player);
            ship.Add(bot);
        }
        else if (ship.Contains(bot))
        {
            textBot.SetActive(false);
            textOff.SetActive(true);
            ship.Remove(bot);
        }
        else
        {
            textOff.SetActive(false);
            textPlayer.SetActive(true);
            ship.Add(player);
        }
    }

    public void P1TeamButton()
    {
        GameObject curr = findShip(P1Team, P1ShipPlayer, P1ShipBot);
        if (curr != null)
        {
            ships[P1Team].Remove(curr);
            P1Team++;
            if (P1Team == 4)
            {
                P1Team = 0;
            }
            ships[P1Team].Add(curr);
        }
    }

    public void P2TeamButton()
    {
        GameObject curr = findShip(P2Team, P2ShipPlayer, P2ShipBot);
        if (curr != null)
        {
            ships[P2Team].Remove(curr);
            P2Team++;
            if (P2Team == 4)
            {
                P2Team = 0;
            }
            ships[P2Team].Add(curr);
        }
    }

    public void P3TeamButton()
    {
        GameObject curr = findShip(P3Team, P3ShipPlayer, P3ShipBot);
        if (curr != null)
        {
            ships[P3Team].Remove(curr);
            P3Team++;
            if (P3Team == 4)
            {
                P3Team = 0;
            }
            ships[P3Team].Add(curr);
        }
    }

    public void P4TeamButton()
    {
        GameObject curr = findShip(P4Team, P4ShipPlayer, P4ShipBot);
        if (curr != null)
        {
            ships[P4Team].Remove(curr);
            P4Team++;
            if (P4Team == 4)
            {
                P4Team = 0;
            }
            ships[P4Team].Add(curr);
        }
    }

    GameObject findShip(int team, GameObject shipTarget, GameObject bot)
    {
        GameObject ans = null;
        List<GameObject> ship = ships[P1Team];
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


    public void rematch()
    {
        endScreen.SetActive(false);
    }

    IEnumerator endRound()
    {
        yield return new WaitForSeconds(1.5f);

        endScreen.SetActive(true);

        //P1WonText.SetActive(false);
        //P2WonText.SetActive(false);
        //P3WonText.SetActive(false);
        //P4WonText.SetActive(false);
        //BotWonText.SetActive(false);
        //DrawText.SetActive(false);

        //if (inGameShips.Count == 0)
        //{
        //    DrawText.SetActive(true);
        //} else if (inGameShips[0] == )
        //{

        //}
        foreach (List<GameObject> shipList in inGameShips)
        {
            while (shipList.Count > 0)
            {
                Destroy(shipList[0]);
                shipList.RemoveAt(0);
            }
        }
    }

    public void endBack()
    {
        endScreen.SetActive(false);
    }


}
