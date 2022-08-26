using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 2;
    int rotatingSpeed = 1;
    bool rotating;

    Vector3 offSet = new Vector3(0, 0, 250);

    public KeyCode turn;
    public KeyCode shoot;

    public GameObject bullet;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotating)
        {
            playerRb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(turn)){
            rotating = true;
        }
        if (Input.GetKeyUp(turn))
        {
            rotating = false;
        }

        if (Input.GetKeyDown(shoot))
        {
            Instantiate(bullet, transform.position + offSet, transform.rotation);
        }

        if (rotating)
        {
            transform.Rotate(0, rotatingSpeed, 0);
        }
 
    }
}
