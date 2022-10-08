using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allShips;
    public List<List<GameObject>> ships;
    public List<List<GameObject>> inGameShips;
    public List<GameObject> inGameIndicators;
    public List<GameObject> inGameAsteroids;
    public List<GameObject> needToClear;

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
    public GameObject botShip1;

    public int spawnRadius;
    int shipY = 10;
    public bool gameStarted;

    public bool fixedSpawn;
    public Text fixedSpawnText;
    public bool bulletCancel;
    public Text bulletCancelText;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);

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
                    ship[i].transform.position = new Vector3(ship[i].transform.position.x, shipY, ship[i].transform.position.z);

                    if (distance(ship[i].transform.position, new Vector3(0, 0, 0)) > spawnRadius)
                    {
                        float angle = Mathf.Atan2(ship[i].transform.position.x, ship[i].transform.position.z);

                        ship[i].transform.position =
                            new Vector3(spawnRadius * Mathf.Sin(angle), shipY, spawnRadius * Mathf.Cos(angle));
                    }
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
                StartCoroutine("scoreScreen");
                gameStarted = false;
            }
        }  
    }

    public void startRound()
    {
        //map
        mapManagerScript.resetMap();
        resetPosRot();

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

            powerUpManagerScript.autoBalance();
        }

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

    IEnumerator scoreScreen()
    {
        yield return new WaitForSeconds(1.5f);
        endRound();
        scoreManagerScript.StartCoroutine("scoreUpdate");
    }

    public void endRound()
    {
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

        //destroy Mines, etc
        while (needToClear.Count > 0)
        {
            Destroy(needToClear[0]);
            needToClear.Remove(needToClear[0]);
        }

        spawnManagerScript.startSpawn = false;
    }

    void resetPosRot()
    {
        pos = new List<Vector3>() {
        new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0)};
        rot = new List<Vector3>() {
        new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0)};

        float radian = Mathf.PI / 2;

        if (! fixedSpawn)
        {
            radian += Random.Range(0, 2 * Mathf.PI);
        }

        for (int i = 0; i < 5; i++)
        {
            pos[i] = new Vector3(spawnRadius * Mathf.Cos(radian), shipY, spawnRadius * Mathf.Sin(radian));
            rot[i] = new Vector3(0, -180 * radian / Mathf.PI, 0);
            radian += 2 * Mathf.PI / 5;
        }      

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

    float distance(Vector3 ship1, Vector3 ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.x - ship2.x), 2) +
            Mathf.Pow((ship1.z - ship2.z), 2));
    }
}
