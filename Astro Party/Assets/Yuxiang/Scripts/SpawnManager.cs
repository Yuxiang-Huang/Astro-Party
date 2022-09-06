using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject smallAsteroid;
    public GameObject mediumpAsteroid;
    public GameObject largeAsteroid;
    public GameObject PowerUpAsteroid;

    PowerUpManager powerUpManagerScript;
    GameManager gameManagerScript;

    public bool startSpawn;

    int space = 50;
     
    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int powerUpA = 0;

        foreach (GameObject asteroid in gameManagerScript.inGameAsteroids)
        {
            if (asteroid.GetComponent<Asteroid>().type  == "powerUp")
            {
                powerUpA++;
            }
        }

        if (startSpawn && powerUpA == 0)
        {
            spawnAsteroids();
        }
    }

    public void RoundSpawn()
    {
        if (powerUpManagerScript.indicators.Count > 0)
        {
            int ran = Random.Range(0, powerUpManagerScript.indicators.Count);
            GameObject powerUp = Instantiate(powerUpManagerScript.indicators[ran], new Vector3(0, 0, 0),
                powerUpManagerScript.indicators[ran].transform.rotation);

            gameManagerScript.inGameIndicators.Add(powerUp);

            startSpawn = true;
        }
    }

    void spawnAsteroids()
    {
        //definitely a powerUp asteroid

        GameObject asteroidClone2 = Instantiate(PowerUpAsteroid, generateRanPos(), PowerUpAsteroid.transform.rotation);

        gameManagerScript.inGameAsteroids.Add(asteroidClone2);

        //spawn number of asteroids = number of ships
        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
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
        Vector3 ranPos = new Vector3(Random.Range(-gameManagerScript.spawnX, gameManagerScript.spawnX), 0,
          Random.Range(-gameManagerScript.spawnZ, gameManagerScript.spawnZ));

        //asteroid distance
        bool flag = true;
        while (flag)
        {
            flag = false;
            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                foreach (GameObject ship in shipList)
                {
                    if (distance(ship.transform.position, ranPos) < space)
                    {
                        flag = true;
                    }
                }
            }
        }
        return ranPos;
    }
}
