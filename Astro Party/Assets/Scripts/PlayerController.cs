using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 20;
    int rotatingSpeed = 1;
    bool rotating;
    int bulletDistance = 250;
    public int ammo;
    public float reloadTime;

    public KeyCode turn;
    public KeyCode shoot;

    public GameObject bullet;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        ammo = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotating)
        {
            playerRb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Force);
        }
        if (Input.GetKeyDown(turn)){
            rotating = true;
        }
        if (Input.GetKeyUp(turn))
        {
            rotating = false;
        }

        if (Input.GetKeyDown(shoot) && ammo > 0)
        {
            ammo--;

            if (reloadTime == 0)
            {
                reloadTime = 2;
            }

            float angle = transform.rotation.ToEulerAngles().y;

            //Debug.Log(Mathf.Cos(transform.rotation.y));
            //Debug.Log(Mathf.Sin(transform.rotation.y));

            Instantiate(bullet, transform.position +
            new Vector3(bulletDistance * Mathf.Sin(angle), 0, bulletDistance * Mathf.Cos(angle)),
            transform.rotation);
        }

        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
            reloadTime = Mathf.Max(reloadTime, 0);
            if (reloadTime == 0)
            {
                ammo++;
            }
        }

        if (ammo < 3 && reloadTime == 0)
        {
            reloadTime = 2;
        }

        if (rotating)
        {
            playerRb.freezeRotation = false;
            transform.Rotate(0, rotatingSpeed, 0);
            playerRb.freezeRotation = true;
        }
 
    }
}
