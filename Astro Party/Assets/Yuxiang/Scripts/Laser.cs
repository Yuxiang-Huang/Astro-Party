using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int id;
    ScoreManager scoreManagerScript;
    PowerUpManager powerUpManagerScript;

    public int team;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        StartCoroutine("selfDestruct");
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pilot"))
        {
            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if(collision.gameObject.GetComponent<PilotPlayerController>() != null)
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

                else if (collision.gameObject.GetComponent<BotPilotMove>() != null)
                {
                    if (team != collision.gameObject.GetComponent<BotPilotMove>().team)
                    {
                        Destroy(collision.gameObject);
                        if (scoreManagerScript.shipMode == "pilot")
                        {
                            earnPoint();
                        }
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
                if (team != collision.gameObject.GetComponent<MutualShip>().team)
                {
                    if (scoreManagerScript.shipMode == "ship")
                    {
                        earnPoint();
                        Destroy(collision.gameObject);
                    }
                    else if (scoreManagerScript.shipMode == "pilot")
                    {
                       collision.gameObject.GetComponent<MutualShip>().spawnPilot(scoreManagerScript.shipMode);                  
                    }
                }
            }
            else
            {
                if (scoreManagerScript.shipMode == "ship")
                {
                    earnPoint();
                    Destroy(collision.gameObject);
                }
                else if (scoreManagerScript.shipMode == "pilot")
                {
                    collision.gameObject.GetComponent<MutualShip>().spawnPilot(scoreManagerScript.shipMode);                  
                }
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
