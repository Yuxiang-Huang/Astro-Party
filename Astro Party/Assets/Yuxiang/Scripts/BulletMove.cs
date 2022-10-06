using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public int id;
    public int team;

    Rigidbody Rb;
    int speed = 1000;

    GameManager gameManagerScript;

    bool attacked;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!attacked)
        {
            if (collision.gameObject.CompareTag("Asteroid"))
            {
                collision.gameObject.GetComponent<Asteroid>().health--;
            }

            if (collision.gameObject.CompareTag("Breakable"))
            {
                collision.gameObject.SetActive(false);
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
            }

            if (!collision.gameObject.CompareTag("Floor"))
            {
                bool destroy = true;
                if (collision.gameObject.CompareTag("Bullet"))
                {
                    if (gameManagerScript.bulletCancel)
                    {
                        destroy = false;
                    }

                    //for scatter shot
                    if (collision.gameObject.GetComponent<BulletMove>().id == id)
                    {
                        destroy = false;
                    }
                }

                if (destroy)
                {
                    Destroy(gameObject);
                    attacked = true;
                }
            }
        }
    }
}
