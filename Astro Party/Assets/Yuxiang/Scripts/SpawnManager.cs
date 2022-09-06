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

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startSpawn && gameManagerScript.inGameAsteroids.Count == 0)
        {
            spawnAsteroids();
        }
    }

    public void RoundSpawn()
    {
        if (powerUpManagerScript.indicators.Count > 0)
        {
            int ran = Random.Range(0, powerUpManagerScript.indicators.Count);
            Instantiate(powerUpManagerScript.indicators[ran], new Vector3(0, 0, 0),
                powerUpManagerScript.indicators[ran].transform.rotation);

            startSpawn = true;
        }
    }

    void spawnAsteroids()
    {
        //spawn number of asteroids = number of ships
        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                Vector3 ranPos = new Vector3(Random.Range(-gameManagerScript.spawnX, gameManagerScript.spawnX), 0,
           Random.Range(-gameManagerScript.spawnZ, gameManagerScript.spawnZ));

                GameObject asteroid = PowerUpAsteroid;

                int ran = Random.Range(0, 4);

                switch (ran)
                {
                    case 0: asteroid = smallAsteroid; break;
                    case 1: asteroid = mediumpAsteroid; break;
                    case 2: asteroid = largeAsteroid; break;
                    case 3: asteroid = PowerUpAsteroid; break;
                }

                GameObject asteroidClone = Instantiate(asteroid, ranPos, PowerUpAsteroid.transform.rotation);

                gameManagerScript.inGameAsteroids.Add(asteroidClone);
            }
        }
    }
}
