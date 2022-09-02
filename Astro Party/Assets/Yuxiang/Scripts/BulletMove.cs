using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    ScoreManager scoreManagerScript;

    public int id;
    Rigidbody Rb;
    int speed = 750;

    public int team;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pilot"))
        {
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (team != collision.gameObject.GetComponent<PilotPlayerController>().team)
                {
                    Destroy(collision.gameObject);
                    if (scoreManagerScript.shipMode == "pilot")
                    {
                        earnPoint();
                    }
                }
            }
            else
            {
                Destroy(collision.gameObject);

                if (scoreManagerScript.shipMode == "pilot")
                {
                    earnPoint();
                }
            }
        }


        if (collision.gameObject.CompareTag("Ship"))
        {
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (team != collision.gameObject.GetComponent<ID>().team)
                {
                    if (collision.gameObject.GetComponent<PlayerController>() != null)
                    {
                        collision.gameObject.GetComponent<PlayerController>().spawnPilot(scoreManagerScript.shipMode);
                    }
                    else if (collision.gameObject.GetComponent<BotMove>() != null)
                    {
                        collision.gameObject.GetComponent<BotMove>().spawnPilot(scoreManagerScript.shipMode);
                    }

                    if (scoreManagerScript.shipMode == "ship")
                    {
                        earnPoint();
                    }
                }
            }
            else
            {
                if (scoreManagerScript.shipMode == "ship")
                {
                    earnPoint();
                }
     
                if (collision.gameObject.GetComponent<PlayerController>() != null)
                {
                    collision.gameObject.GetComponent<PlayerController>().spawnPilot(scoreManagerScript.shipMode);
                }
                else if (collision.gameObject.GetComponent<BotMove>() != null)
                {
                    collision.gameObject.GetComponent<BotMove>().spawnPilot(scoreManagerScript.shipMode);
                }
            }
        }

        if (!collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }

    void earnPoint()
    {
        if (scoreManagerScript.gameMode == "solo")
        {
            switch (id)
            {
                case 1:
                    scoreManagerScript.P1Score++;
                    break;
                case 2:
                    scoreManagerScript.P2Score++;
                    break;
                case 3:
                    scoreManagerScript.P3Score++;
                    break;
                case 4:
                    scoreManagerScript.P4Score++;
                    break;
            }
        }
    }
}
