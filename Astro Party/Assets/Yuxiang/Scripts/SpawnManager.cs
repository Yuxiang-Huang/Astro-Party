using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PowerUpAsteroid;

    PowerUpManager powerUpManagerScript;
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundSpawn()
    {
        if (powerUpManagerScript.indicators.Count > 0)
        {
            int ran = Random.Range(0, powerUpManagerScript.indicators.Count);
            Instantiate(powerUpManagerScript.indicators[ran], new Vector3(0, 0, 0),
                powerUpManagerScript.indicators[ran].transform.rotation);

            InvokeRepeating("spawnPowerUpAsteroid", 0, 5);
        }
    }

    void spawnPowerUpAsteroid()
    {
        Vector3 ranPos = new Vector3(Random.Range(-gameManagerScript.spawnX, gameManagerScript.spawnX), 0, 
            Random.Range(-gameManagerScript.spawnZ, gameManagerScript.spawnZ));
        Instantiate(PowerUpAsteroid, ranPos, PowerUpAsteroid.transform.rotation);
    }
}
