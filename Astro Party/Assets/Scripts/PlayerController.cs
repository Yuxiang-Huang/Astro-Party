using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 2;
    int rotatingSpeed = 1;
    Rigidbody playerRb;
    bool rotating;

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
        if (Input.GetKeyDown(KeyCode.A)){
            rotating = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rotating = false;
        }

        if (rotating)
        {
            transform.Rotate(0, rotatingSpeed, 0);
        }
 
    }
}
