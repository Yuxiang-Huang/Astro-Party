using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 500;
    int maxVelocity = 350;
    float rotatingSpeed = 1.5f;
    bool rotating;

    public KeyCode turn;
    public KeyCode shoot;

    Rigidbody playerRb;

    bool dash;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shoot))
        {
            GetComponent<MutualShip>().shoot();
        }

        if (Input.GetKeyDown(turn))
        {
            rotating = true;
            if (dash)
            {
                transform.Rotate(0, 90, 0);
                //change velocity
                playerRb.velocity = new Vector3(playerRb.velocity.z, playerRb.velocity.y, -playerRb.velocity.x);

                //translate
                float angle = transform.rotation.ToEulerAngles().y;
                transform.position = new Vector3(transform.position.x + 100 * Mathf.Sin(angle),
                    transform.position.y, transform.position.z + 100 * Mathf.Cos(angle));

                dash = false;
            }
            else
            {
                StartCoroutine("dashCountDown");
            }
        }
        if (Input.GetKeyUp(turn))
        {
            rotating = false;
        }

        if (rotating && playerRb.constraints != RigidbodyConstraints.FreezePosition)
        {
            playerRb.freezeRotation = false;
            transform.Rotate(0, rotatingSpeed, 0);
            playerRb.freezeRotation = true;
        }

        //if (!rotating)
        playerRb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Force);

        if (playerRb.velocity.magnitude > maxVelocity)
        {
            //Debug.Log(playerRb.velocity);
            playerRb.velocity = playerRb.velocity.normalized * maxVelocity;
        }
    }

    IEnumerator dashCountDown()
    {
        dash = true;
        yield return new WaitForSeconds(1.0f);
        dash = false;
    }
}
