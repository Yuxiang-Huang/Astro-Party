using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotPlayerController : MonoBehaviour
{
    int myID;

    int speed = 100;
    float rotatingSpeed = 3f;
    bool rotating;
    bool moving;

    public KeyCode turn = KeyCode.A;
    public KeyCode move = KeyCode.D;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(move))
        {
            moving = true;
        }
        if (Input.GetKeyUp(move))
        {
            moving = false;
        }
        if (moving)
        {
            playerRb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Force);
        }

        if (Input.GetKeyDown(turn))
        {
            rotating = true;
        }
        if (Input.GetKeyUp(turn))
        {
            rotating = false;
        }
        
        if (rotating)
        {
            playerRb.freezeRotation = false;
            transform.Rotate(0, rotatingSpeed, 0);
            playerRb.freezeRotation = true;
        }
    }
}
