using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
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
                Instantiate(PowerUpAsteroid, ranPos, PowerUpAsteroid.transform.rotation);
            }
        }
    }
}
