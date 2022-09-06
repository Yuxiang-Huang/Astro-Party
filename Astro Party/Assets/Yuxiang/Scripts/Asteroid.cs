using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public string type;

    PowerUpManager powerUpManagerScript;

    public int health;

    GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();

        switch (type)
        {
            case "large": health = 3; break;

            case "medium": health = 2; break;

            case "small": health = 1; break;

            case "powerUp": health = 1;
                powerUp = powerUpManagerScript.indicators[Random.Range(0, powerUpManagerScript.indicators.Count)];
                break;
        }
    }

    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        if (type == "powerUp")
        {
            Instantiate(powerUp, transform.position, powerUp.transform.rotation);
        }
    }
}
