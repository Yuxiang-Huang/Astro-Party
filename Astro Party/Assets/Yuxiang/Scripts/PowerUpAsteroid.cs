using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAsteroid : MonoBehaviour
{
    PowerUpManager powerUpManagerScript;

    int health;

    GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();

        powerUp = powerUpManagerScript.indicators[Random.Range(0, powerUpManagerScript.indicators.Count)];

        health = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
            Instantiate(powerUp, transform.position, powerUp.transform.rotation);
        }
    }
}
