using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    ScoreManager scoreManagerScript;

    public int id;
    Rigidbody Rb;
    int speed = 750;

    public List<int> team;

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

            if (! team.Contains(collision.gameObject.GetComponent<ID>().id)){
                Destroy(collision.gameObject);
            }
        }

        if (! collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
