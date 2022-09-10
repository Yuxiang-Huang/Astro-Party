using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public int id;

    public int team;

    ScoreManager scoreManagerScript;

    SEManager SEManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        StartCoroutine("selfDestruct");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            bool toFreeze = true;
            if (!scoreManagerScript.friendlyFire)
            {
                if (team == collision.gameObject.GetComponent<MutualShip>().team)
                {
                    toFreeze = false;
                }
            }

            //don't freeze yourself
            if (id == collision.gameObject.GetComponent<MutualShip>().id)
            {
                toFreeze = false;
            }

            if (toFreeze)
            {
                if (collision.gameObject.GetComponent<PlayerController>() != null)
                {
                    collision.gameObject.GetComponent<PlayerController>().StartCoroutine("beginFreeze");
                }
                else if (collision.gameObject.GetComponent<BotMove>() != null)
                {
                    collision.gameObject.GetComponent<BotMove>().StartCoroutine("beginDisable");
                }
                collision.gameObject.GetComponent<MutualShip>().freezed.SetActive(true);
            }
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

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
