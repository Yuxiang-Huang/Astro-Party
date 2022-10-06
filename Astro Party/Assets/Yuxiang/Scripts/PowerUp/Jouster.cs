using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouster : MonoBehaviour
{
    public int id;
    public int team;
    public int health;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            health -= collision.gameObject.GetComponent<Asteroid>().health;
            collision.gameObject.GetComponent<Asteroid>().health = 0;
        }

        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.SetActive(false);
            health -= 1;
        }

        if (collision.gameObject.CompareTag("Pilot"))
        {
            if (collision.gameObject.GetComponent<PilotPlayerController>() != null)
            {
                collision.gameObject.GetComponent<PilotPlayerController>().kill(id, team);
            }
            else
            {
                collision.gameObject.GetComponent<BotPilotMove>().kill(id, team);
            }
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<MutualShip>().damage(id, team);
            health = 0;
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
