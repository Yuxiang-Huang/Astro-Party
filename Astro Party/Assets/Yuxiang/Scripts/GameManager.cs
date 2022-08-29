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
    public GameObject P1WonText;
    public GameObject P2WonText;
    public GameObject P3WonText;
    public GameObject P4WonText;
    public GameObject BotWonText;
    public GameObject DrawText;

    public GameObject blueShipPlayer;
    public GameObject blueShipBot;
    public GameObject blueTextPlayer;
    public GameObject blueTextBot;
    public GameObject blueTextOff;
    int blueTeam = 0;

    public GameObject redShipPlayer;
    public GameObject redShipBot;
    public GameObject redTextPlayer;
    public GameObject redTextBot;
    public GameObject redTextOff;
    int redTeam = 1;

    public GameObject yellowShipPlayer;
    public GameObject yellowShipBot;
    public GameObject yellowTextPlayer;
    public GameObject yellowTextBot;
    public GameObject yellowTextOff;
    int yellowTeam = 2;

    public GameObject cyanShipPlayer;
    public GameObject cyanShipBot;
    public GameObject cyanTextPlayer;
    public GameObject cyanTextBot;
    public GameObject cyanTextOff;
    int cyanTeam = 3;

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
        buttonHelper(blueShipPlayer, blueShipBot, blueTextPlayer, blueTextBot, blueTextOff, blueTeam);
    }

    public void P2Button()
    {
        buttonHelper(redShipPlayer, redShipBot, redTextPlayer, redTextBot, redTextOff, redTeam);
    }

    public void P3Button()
    {
        buttonHelper(yellowShipPlayer, yellowShipBot, yellowTextPlayer, yellowTextBot, yellowTextOff, yellowTeam);
    }

    public void P4Button()
    {
        buttonHelper(cyanShipPlayer, cyanShipBot, cyanTextPlayer, cyanTextBot, cyanTextOff, cyanTeam);
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
        GameObject curr = findShip(blueTeam, blueShipPlayer, blueShipBot);
        if (curr != null)
        {
            ships[blueTeam].Remove(curr);
            blueTeam++;
            if (blueTeam == 4)
            {
                blueTeam = 0;
            }
            ships[blueTeam].Add(curr);
        }
    }

    //public void P2TeamButton()
    //{
    //    buttonHelper(redShipPlayer, redShipBot, redTextPlayer, redTextBot, redTextOff, redTeam);
    //}

    //public void P3TeamButton()
    //{
    //    buttonHelper(yellowShipPlayer, yellowShipBot, yellowTextPlayer, yellowTextBot, yellowTextOff, yellowTeam);
    //}

    //public void P4TeamButton()
    //{
    //    buttonHelper(cyanShipPlayer, cyanShipBot, cyanTextPlayer, cyanTextBot, cyanTextOff, cyanTeam);
    //}

    GameObject findShip(int team, GameObject shipTarget, GameObject bot)
    {
        GameObject ans = null;
        List<GameObject> ship = ships[blueTeam];
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
