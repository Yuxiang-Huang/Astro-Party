using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int id;
    ScoreManager scoreManagerScript;
    PowerUpManager powerUpManagerScript;
    SEManager SEManagerScript;

    public int team;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        StartCoroutine("selfDestruct");
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
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