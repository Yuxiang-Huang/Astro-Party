using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int id;
    ScoreManager scoreManagerScript;

    public int team;

    // Start is called before the first frame update
    void Start()
    {
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
        if (collision.gameObject.CompareTag("Ship"))
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

            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if (!team.Contains(collision.gameObject.GetComponent<ID>().id))
                {
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
