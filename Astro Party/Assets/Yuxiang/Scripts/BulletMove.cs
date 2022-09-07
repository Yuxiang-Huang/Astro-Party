using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    ScoreManager scoreManagerScript;
    PowerUpManager powerUpManagerScript;
    SEManager SEManagerScript;

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
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();
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
            bool toKill = true;
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (collision.gameObject.GetComponent<PilotPlayerController>() != null)
                {
                    if (team == collision.gameObject.GetComponent<PilotPlayerController>().team)
                    {
                        toKill = false;
                    }
                }

                else if (collision.gameObject.GetComponent<BotPilotMove>() != null)
                {
                    if (team == collision.gameObject.GetComponent<BotPilotMove>().team)
                    {
                        toKill = false;
                    }
                }
            }
            if (toKill)
            {
                //sound effect
                SEManagerScript.generalAudio.PlayOneShot(SEManagerScript.pilotDeath);

                Destroy(collision.gameObject);

                if (scoreManagerScript.shipMode == "pilot")
                {
                    earnPoint();
                }
            }
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            bool toKill = true;
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (team == collision.gameObject.GetComponent<MutualShip>().team)
                {
                    toKill = false;
                }
            }

            if (toKill)
            {
                //ship explode sound effect
                SEManagerScript.generalAudio.PlayOneShot(SEManagerScript.shipExplode);

                powerUpManagerScript.dropItem(collision.gameObject.GetComponent<MutualShip>());

                if (scoreManagerScript.shipMode == "ship")
                {
                    earnPoint();
                    Destroy(collision.gameObject);
                }
                else if (scoreManagerScript.shipMode == "pilot")
                {
                    collision.gameObject.GetComponent<MutualShip>().spawnPilot();
                }
            }
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
            }
        }
    }
}
