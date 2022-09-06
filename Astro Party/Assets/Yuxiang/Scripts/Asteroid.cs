using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public string type;

    PowerUpManager powerUpManagerScript;
    GameManager gameManagerScript;

    public int health;

    GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

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
            gameManagerScript.inGameAsteroids.Remove(gameObject);
            Destroy(gameObject);

            if (type == "powerUp")
            {
                GameObject toAdd = Instantiate(powerUp, transform.position, powerUp.transform.rotation);

                gameManagerScript.inGameIndicators.Add(toAdd);
            }
        }
    }
}
