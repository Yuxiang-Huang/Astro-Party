using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            collision.gameObject.GetComponent<Asteroid>().health = 0;
        }

        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Pilot"))
        {
            if (collision.gameObject.GetComponent<PilotPlayerController>() != null)
            {
                collision.gameObject.GetComponent<PilotPlayerController>().kill(-1, -1);
            }
            else
            {
                collision.gameObject.GetComponent<BotPilotMove>().kill(-1, -1);
            }
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<MutualShip>().damage(-1, -1);
        }
    }
}
