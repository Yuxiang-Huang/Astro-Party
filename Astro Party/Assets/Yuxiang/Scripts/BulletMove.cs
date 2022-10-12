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
    ScoreManager scoreManagerScript;

    bool attacked;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
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
                    if (collision.gameObject.GetComponent<PilotPlayerController>().id == id)
                    {
                        if (gameManagerScript.suicidalBullet)
                        {
                            suicide();
                        }
                    }
                    else
                    {
                        collision.gameObject.GetComponent<PilotPlayerController>().kill(id, team);
                    }
                }
                else
                {
                    if (collision.gameObject.GetComponent<BotPilotMove>().id == id)
                    {
                        if (gameManagerScript.suicidalBullet)
                        {
                            suicide();
                        }
                    }
                    else
                    {
                        collision.gameObject.GetComponent<BotPilotMove>().kill(id, team);
                    }
                }
            }
            if (collision.gameObject.CompareTag("Ship"))
            {
                if (collision.gameObject.GetComponent<MutualShip>().id == id)
                {
                    if (gameManagerScript.suicidalBullet)
                    {
                        suicide();
                    }
                }
                else
                {
                    collision.gameObject.GetComponent<MutualShip>().damage(id, team);
                }
            }

            if (!collision.gameObject.CompareTag("Floor"))
            {
                bool destroy = true;
                if (collision.gameObject.CompareTag("Bullet"))
                {
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

    void suicide()
    {
        if (scoreManagerScript.gameMode == "solo")
        {
            switch (id)
            {
                case 1:
                    scoreManagerScript.P1Suicide = true;
                    break;
                case 2:
                    scoreManagerScript.P2Suicide = true;
                    break;
                case 3:
                    scoreManagerScript.P3Suicide = true;
                    break;
                case 4:
                    scoreManagerScript.P4Suicide = true;
                    break;
                case 5:
                    scoreManagerScript.P5Suicide = true;
                    break;
            }
        }
    }
}
