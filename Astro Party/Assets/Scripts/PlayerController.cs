using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 10;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.A)){
            transform.Rotate(0, 10, 0); 
        }
    }
}
