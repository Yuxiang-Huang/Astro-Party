using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    ScoreManager scoreManagerScript;

    public int id;
    Rigidbody Rb;
    int speed = 1000;

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
                if (collision.gameObject.GetComponent<BulletMove>().id == id)
                {
                    destroy = false;
                }
            }

            if (destroy)
            {
                Destroy(gameObject);
            }
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
                case 5:
                    scoreManagerScript.P5Score++;
                    break;
            }
        }
    }
}
