using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<List<GameObject>> ships;
    public List<List<GameObject>> inGameShips;
    public List<GameObject> inGameIndicators;
    public List<GameObject> inGameAsteroids;

    List<Vector3> pos;
    List<Vector3> rot;

    ScoreManager scoreManagerScript;
    MapManager mapManagerScript;
    SEManager SEManagerScript;
    SpawnManager spawnManagerScript;
    PowerUpManager powerUpManagerScript;
    ScreenManager screenManagerScript;

    public GameObject nextButton;

    public GameObject playerShip;
    public GameObject botShip;

    public GameObject P1ShipPlayer;
    public GameObject P1ShipBot;
    public GameObject P1TextPlayer;
    public GameObject P1TextBot;
    public GameObject P1TextOff;
    public int P1Team = 0;
    public GameObject P1TeamButtonObject;
    public GameObject P1SetRotateButton;
    public GameObject P1SetShootButton;
    public GameObject P1StartingPowerUpButton;

    public GameObject P2ShipPlayer;
    public GameObject P2ShipBot;
    public GameObject P2TextPlayer;
    public GameObject P2TextBot;
    public GameObject P2TextOff;
    public int P2Team = 1;
    public GameObject P2TeamButtonObject;
    public GameObject P2SetRotateButton;
    public GameObject P2SetShootButton;
    public GameObject P2StartingPowerUpButton;

    public GameObject P3ShipPlayer;
    public GameObject P3ShipBot;
    public GameObject P3TextPlayer;
    public GameObject P3TextBot;
    public GameObject P3TextOff;
    public int P3Team = 2;
    public GameObject P3TeamButtonObject;
    public GameObject P3SetRotateButton;
    public GameObject P3SetShootButton;
    public GameObject P3StartingPowerUpButton;

    public GameObject P4ShipPlayer;
    public GameObject P4ShipBot;
    public GameObject P4TextPlayer;
    public GameObject P4TextBot;
    public GameObject P4TextOff;
    public int P4Team = 3;
    public GameObject P4TeamButtonObject;
    public GameObject P4SetRotateButton;
    public GameObject P4SetShootButton;
    public GameObject P4StartingPowerUpButton;

    public GameObject P5ShipPlayer;
    public GameObject P5ShipBot;
    public GameObject P5TextPlayer;
    public GameObject P5TextBot;
    public GameObject P5TextOff;
    public int P5Team = 4;
    public GameObject P5TeamButtonObject;
    public GameObject P5SetRotateButton;
    public GameObject P5SetShootButton;
    public GameObject P5StartingPowerUpButton;

    public int spawnX;
    public int spawnZ;
    public bool gameStarted;

    bool fixedSpawn;
    public Text fixedSpawnText;
    public bool bulletCancel;
    public Text bulletCancelText;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
        resetPosRot();

        ships = new List<List<GameObject>>() {new List<GameObject>(), new List<GameObject>(), new List<GameObject>(),
        new List<GameObject>(), new List<GameObject>()};

        inGameShips = new List<List<GameObject>>() {new List<GameObject>(), new List<GameObject>(), new List<GameObject>(),
        new List<GameObject>(), new List<GameObject>()};

        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        mapManagerScript = GameObject.Find("Map Manager").GetComponent<MapManager>();
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        screenManagerScript = GameObject.Find("Screen Manager").GetComponent<ScreenManager>();

        //Creating ships
        P1ShipBot = Instantiate(botShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P1ShipBot.GetComponent<MutualShip>().id = 1;

        P2ShipBot = Instantiate(botShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P2ShipBot.GetComponent<MutualShip>().id = 2;

        P3ShipBot = Instantiate(botShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P3ShipBot.GetComponent<MutualShip>().id = 3;

        P4ShipBot = Instantiate(botShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P4ShipBot.GetComponent<MutualShip>().id = 4;

        P5ShipBot = Instantiate(botShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P5ShipBot.GetComponent<MutualShip>().id = 5;

        P1ShipBot.SetActive(false);
        P2ShipBot.SetActive(false);
        P3ShipBot.SetActive(false);
        P4ShipBot.SetActive(false);
        P5ShipBot.SetActive(false);

        P1ShipPlayer = Instantiate(playerShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P1ShipPlayer.GetComponent<MutualShip>().id = 1;

        P2ShipPlayer = Instantiate(playerShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P2ShipPlayer.GetComponent<MutualShip>().id = 2;

        P3ShipPlayer = Instantiate(playerShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P3ShipPlayer.GetComponent<MutualShip>().id = 3;

        P4ShipPlayer = Instantiate(playerShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P4ShipPlayer.GetComponent<MutualShip>().id = 4;

        P5ShipPlayer = Instantiate(playerShip, new Vector3(0, 0, 0), playerShip.transform.rotation);
        P5ShipPlayer.GetComponent<MutualShip>().id = 5;

        P1ShipPlayer.SetActive(false);
        P2ShipPlayer.SetActive(false);
        P3ShipPlayer.SetActive(false);
        P4ShipPlayer.SetActive(false);
        P5ShipPlayer.SetActive(false);
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
                else
                {
                    //prevent out of bound
                    ship[i].transform.position = new Vector3(Mathf.Max(ship[i].transform.position.x, -spawnX),
                        ship[i].transform.position.y, Mathf.Max(ship[i].transform.position.z, -spawnZ));
                    ship[i].transform.position = new Vector3(Mathf.Min(ship[i].transform.position.x, spawnX),
                        ship[i].transform.position.y, Mathf.Min(ship[i].transform.position.z, spawnZ));
                }
            }
        }

        //remove killed indicators
        for (int i = inGameIndicators.Count - 1; i >= 0; i--)
        {
            if (inGameIndicators[i] == null)
            {
                inGameIndicators.RemoveAt(i);
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

    public void startRound()
    {
        //Starting PowerUP
        string startingPowerUp = "normal";
        bool hasSPU = false;

        if (powerUpManagerScript.allRandomSPU)
        {
            hasSPU = true;
            startingPowerUp = powerUpManagerScript.SPU[Random.Range(0, powerUpManagerScript.SPU.Count)];
        }

        //sound effect
        SEManagerScript.generalAudio.PlayOneShot(SEManagerScript.ready);

        //call other scripts
        spawnManagerScript.RoundSpawn();
        mapManagerScript.resetMap();

        gameStarted = true;

        //spawn ships
        for (int i = 0; i < ships.Count; i++)
        {
            for (int j = 0; j < ships[i].Count; j++)
            {
                int ran;
                if (fixedSpawn)
                {
                    ran = ships[i][j].GetComponent<MutualShip>().id - 1;
                }
                else
                {
                    ran = Random.Range(0, pos.Count);
                }

                //spawn position
                inGameShips[i].Add(Instantiate(ships[i][j], pos[ran], ships[i][j].transform.rotation));
                inGameShips[i][j].transform.Rotate(rot[ran]);

                inGameShips[i][j].GetComponent<MutualShip>().team = i;

                if (inGameShips[i][j].GetComponent<MutualShip>().shootMode == "normal")
                {
                    inGameShips[i][j].GetComponent<MutualShip>().shootMode = startingPowerUp;
                }

                if (inGameShips[i][j].GetComponent<MutualShip>().shootMode == "Random Starting PowerUp")
                {
                    hasSPU = true;
                    inGameShips[i][j].GetComponent<MutualShip>().shootMode =
                        powerUpManagerScript.SPU[Random.Range(0, powerUpManagerScript.SPU.Count)]; ;
                }

                inGameShips[i][j].SetActive(true);

                //begin freeze
                inGameShips[i][j].GetComponent<MutualShip>().freezeTime = 2.0f;

                if (!fixedSpawn)
                {
                    pos.RemoveAt(ran);
                    rot.RemoveAt(ran);
                }
            }
        }

        resetPosRot();

        if (hasSPU)
        {
            screenManagerScript.StartCoroutine("startingPowerUp");
            for (int i = 0; i < ships.Count; i++)
            {
                for (int j = 0; j < ships[i].Count; j++)
                {
                    inGameShips[i][j].GetComponent<MutualShip>().freezeTime += 1.0f;
                }
            }
        }
    }

    //Buttons

    public void P1Button()
    {
        buttonHelper(P1ShipPlayer, P1ShipBot, P1TextPlayer, P1TextBot, P1TextOff, P1Team, P1TeamButtonObject,
            P1SetRotateButton, P1SetShootButton, scoreManagerScript.P1, P1StartingPowerUpButton);
    }

    public void P2Button()
    {
        buttonHelper(P2ShipPlayer, P2ShipBot, P2TextPlayer, P2TextBot, P2TextOff, P2Team, P2TeamButtonObject,
            P2SetRotateButton, P2SetShootButton, scoreManagerScript.P2, P2StartingPowerUpButton);
    }

    public void P3Button()
    {
        buttonHelper(P3ShipPlayer, P3ShipBot, P3TextPlayer, P3TextBot, P3TextOff, P3Team, P3TeamButtonObject,
            P3SetRotateButton, P3SetShootButton, scoreManagerScript.P3, P3StartingPowerUpButton);
    }

    public void P4Button()
    {
        buttonHelper(P4ShipPlayer, P4ShipBot, P4TextPlayer, P4TextBot, P4TextOff, P4Team, P4TeamButtonObject,
            P4SetRotateButton, P4SetShootButton, scoreManagerScript.P4, P4StartingPowerUpButton);
    }

    public void P5Button()
    {
        buttonHelper(P5ShipPlayer, P5ShipBot, P5TextPlayer, P5TextBot, P5TextOff, P5Team, P5TeamButtonObject,
            P5SetRotateButton, P5SetShootButton, scoreManagerScript.P5, P5StartingPowerUpButton);
    }

    void buttonHelper(GameObject player, GameObject bot, GameObject textPlayer, GameObject textBot, GameObject textOff,
        int team, GameObject teamButton, GameObject setRotateButton, GameObject setShootButton, GameObject picture,
            GameObject startingPowerUpButton)
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
            picture.SetActive(false);
            startingPowerUpButton.SetActive(false);
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
            startingPowerUpButton.SetActive(true);
        }
    }

    public void P1TeamButton()
    {
        GameObject curr = findShip(P1Team, P1ShipPlayer, P1ShipBot);
        
        ships[P1Team].Remove(curr);
        P1Team++;

        if (P1Team == 5)
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

        if (P2Team == 5)
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
        if (P3Team == 5)
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
        if (P4Team == 5)
        {
            P4Team = 0;
        }
        ships[P4Team].Add(curr);   
    }

    public void P5TeamButton()
    {
        GameObject curr = findShip(P5Team, P5ShipPlayer, P5ShipBot);

        ships[P5Team].Remove(curr);
        P5Team++;
        if (P5Team == 5)
        {
            P5Team = 0;
        }
        ships[P5Team].Add(curr);
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

            //reward for team winner
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
                            case 5:
                                scoreManagerScript.P5Score++;
                                break;
                        }
                    }
                }
            }

            //destroy ships
            while (shipList.Count > 0)
            {
                Destroy(shipList[0]);
                shipList.RemoveAt(0);
            }
        }

        //destroy powerUps
        while (inGameIndicators.Count > 0)
        {
            Destroy(inGameIndicators[0]);
            inGameIndicators.Remove(inGameIndicators[0]);
        }

        //destroy Asteroids
        while (inGameAsteroids.Count > 0)
        {
            Destroy(inGameAsteroids[0]);
            inGameAsteroids.Remove(inGameAsteroids[0]);
        }

        spawnManagerScript.startSpawn = false;
        scoreManagerScript.StartCoroutine("scoreUpdate");
    }

    void resetPosRot()
    {
        pos = new List<Vector3>() { new Vector3(-spawnX, 15, spawnZ), new Vector3(spawnX, 15, spawnZ),
        new Vector3(-spawnX, 15, -spawnZ), new Vector3(spawnX, 15, -spawnZ),
            new Vector3(0, 15, -spawnZ) };
        rot = new List<Vector3>() {new Vector3(0, 90, 0), new Vector3(0, 180, 0),
        new Vector3(0, 0, 0), new Vector3(0, -90, 0),
            new Vector3(0, -45, 0)};
    }

    public void setFixedSpawn()
    {
        if (fixedSpawn)
        {
            fixedSpawnText.text = "Fixed Spawn: Off";
        }
        else
        {
            fixedSpawnText.text = "Fixed Spawn: On";
        }
        fixedSpawn = !fixedSpawn;
    }

    public void setBulletCancel()
    {
        if (bulletCancel)
        {
            bulletCancelText.text = "Bullet Cancel: Off";
        }
        else
        {
            bulletCancelText.text = "Bullet Cancel: On";
        }
        bulletCancel = !bulletCancel;
    }
}
