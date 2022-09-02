using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    public int id;
    public int team;
    ScoreManager scoreManagerScript;

    // Start is called before the first frame update
    void Start()
    {
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
