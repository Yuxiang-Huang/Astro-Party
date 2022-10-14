using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public string mode;
    public Text modeText; 

    public GameObject smallAsteroid;
    public GameObject mediumpAsteroid;
    public GameObject largeAsteroid;
    public GameObject PowerUpAsteroid;

    PowerUpManager powerUpManagerScript;
    GameManager gameManagerScript;

    public bool startSpawn;

    int space = 100;

    int shipNum;
     
    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        mode = "some";
    }

    // Update is called once per frame
    void Update()
    {
        //spawn asteroid when no more powerUp asteroid
        if (startSpawn && powerUpManagerScript.indicators.Count > 0)
        {
            bool spawn = true;

            foreach (GameObject asteroid in gameManagerScript.inGameAsteroids)
            {
                if (asteroid.GetComponent<Asteroid>().type == "powerUp")
                {
                    spawn = false;
                }
            }

            if (spawn)
            {
                //shipNum = 0;

                //foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
                //{
                //    shipNum += shipList.Count;
                //}

                //switch (mode)
                //{
                //    case "few": shipNum = shipNum / 2; break;
                //    case "many": shipNum = shipNum * 2; break;
                //}

                //for (int i = 0; i < shipNum; i++)
                //{
                //    GameObject asteroidClone = Instantiate(PowerUpAsteroid, generateRanPos(), PowerUpAsteroid.transform.rotation);

                //    gameManagerScript.inGameAsteroids.Add(asteroidClone);
                //}

                spawnAsteroids();
            }
        }
    }

    public void RoundSpawn()
    {
        if (powerUpManagerScript.indicators.Count > 0)
        {
            int ran = Random.Range(0, powerUpManagerScript.indicators.Count);

            GameObject powerUp = Instantiate(powerUpManagerScript.indicators[ran],
                new Vector3(0, powerUpManagerScript.powerUpyValue, 0),
                powerUpManagerScript.indicators[ran].transform.rotation);

            gameManagerScript.inGameIndicators.Add(powerUp);
        }
        else
        {
            //if no indicators, no powerUp asteroid
            switch (Random.Range(0, 3))
            {
                case 0: PowerUpAsteroid = smallAsteroid; break;
                case 1: PowerUpAsteroid = mediumpAsteroid; break;
                case 2: PowerUpAsteroid = largeAsteroid; break;
            }
        }

        startSpawn = true;
    }

    void spawnAsteroids()
    {
        if (mode != "none")
        {
            //definitely a powerUp asteroid
            GameObject asteroidClone2 = Instantiate(PowerUpAsteroid, generateRanPos(), PowerUpAsteroid.transform.rotation);

            gameManagerScript.inGameAsteroids.Add(asteroidClone2);

            shipNum = 0;

            //spawn number of asteroids = number of ships
            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                shipNum += shipList.Count;
            }

            switch (mode)
            {
                case "few": shipNum = shipNum / 2; break;
                case "many": shipNum = shipNum * 2; break;
            }

            for (int i = 0; i < shipNum; i++)
            {
                GameObject asteroid = PowerUpAsteroid;

                int ran = Random.Range(0, 4);

                switch (ran)
                {
                    case 0: asteroid = smallAsteroid; break;
                    case 1: asteroid = mediumpAsteroid; break;
                    case 2: asteroid = largeAsteroid; break;
                    case 3: asteroid = PowerUpAsteroid; break;
                }

                GameObject asteroidClone = Instantiate(asteroid, generateRanPos(), PowerUpAsteroid.transform.rotation);

                gameManagerScript.inGameAsteroids.Add(asteroidClone);
            }
        }
    }

    float distance(Vector3 ship1, Vector3 ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.x - ship2.x), 2) + Mathf.Pow((ship1.z - ship2.z), 2));
    }

    Vector3 generateRanPos()
    {
        Vector3 ranPos = new Vector3(Random.Range(-gameManagerScript.spawnRadius, gameManagerScript.spawnRadius), -10,
          Random.Range(-gameManagerScript.spawnRadius, gameManagerScript.spawnRadius));

        //outside the circle
        bool flag = true;
        while (flag)
        {
            flag = false;

            ranPos = new Vector3(Random.Range(-gameManagerScript.spawnRadius, gameManagerScript.spawnRadius), -10,
Random.Range(-gameManagerScript.spawnRadius, gameManagerScript.spawnRadius));

            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                foreach (GameObject ship in shipList)
                {
                    if (ship != null)
                    {
                        if (distance(ship.transform.position, ranPos) < space)
                        {
                            flag = true;
                        }
                    }
                }
            }

            if (distance(ranPos, new Vector3(0, 0, 0)) > gameManagerScript.spawnRadius)
            {
                flag = true;
            }
        }
        return ranPos;
    }

    public void changeMode()
    {
        switch (mode)
        {
            case "some": mode = "many"; modeText.text = "Asteroids: Many"; break;
            case "many": mode = "none"; modeText.text = "Asteroids: None"; break;
            case "none": mode = "few"; modeText.text = "Asteroids: Few"; break;
            case "few": mode = "some"; modeText.text = "Asteroids: Some"; break;
        }
    }
}
