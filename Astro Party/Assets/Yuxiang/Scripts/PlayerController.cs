using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 350;
    float rotatingSpeed = 1.5f;
    bool rotating;
    int bulletDis = 75;
    public int ammo;
    public float reloadTime;
    public float bulletAnimationPos;

    public string shootMode;
    //normal, laser

    public AudioClip laserSound;

    public KeyCode turn;
    public KeyCode shoot;

    public GameObject laser;
    public GameObject bullet;
    public GameObject[] bulletAnimation;

    Rigidbody playerRb;
    AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        ammo = 3;

        shootMode = "laser";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shoot))
        {
            float angle = transform.rotation.ToEulerAngles().y;

            if (shootMode == "laser")
            {
                //5000 is half the length of laserbeam
                Instantiate(laser, transform.position +
                new Vector3((bulletDis + 5000) * Mathf.Sin(angle), 0, (bulletDis + 5000) * Mathf.Cos(angle)),
                transform.rotation);

                playerAudio.PlayOneShot(laserSound);

                playerRb.constraints = RigidbodyConstraints.FreezePosition;

                StartCoroutine("ableToMove");

                shootMode = "normal";
            }

            else if (shootMode == "normal" && ammo > 0)
            {
                ammo--;

                bulletAnimation[ammo].SetActive(false);

                if (reloadTime == 0)
                {
                    reloadTime = 2;
                }
           
                //Debug.Log(Mathf.Cos(transform.rotation.y));
                //Debug.Log(Mathf.Sin(transform.rotation.y));

                Instantiate(bullet, transform.position +
                new Vector3(bulletDis * Mathf.Sin(angle), 0, bulletDis * Mathf.Cos(angle)),
                transform.rotation);
            }  
        }

        //if (!rotating)
        //{
        playerRb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Force);

        
        if (Input.GetKeyDown(turn)){
            rotating = true;
        }
        if (Input.GetKeyUp(turn))
        {
            rotating = false;
        }

        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
            reloadTime = Mathf.Max(reloadTime, 0);
            if (reloadTime == 0)
            {
                ammo++;
                bulletAnimation[ammo - 1].SetActive(true);
            }
        }

        if (ammo < 3 && reloadTime == 0)
        {
            reloadTime = 2;
        }

        if (rotating && playerRb.constraints != RigidbodyConstraints.FreezePosition)
        {
            playerRb.freezeRotation = false;
            transform.Rotate(0, rotatingSpeed, 0);
            playerRb.freezeRotation = true;
        }

        bulletAnimationPos += Time.deltaTime;

        for (int i = 0; i < bulletAnimation.Length; i++)
        {

            bulletAnimation[i].transform.position = new Vector3(transform.position.x +
                Mathf.Cos(bulletAnimationPos + i * 2 * Mathf.PI / 3) * bulletDis,
                transform.position.y, transform.position.z + Mathf.Sin(bulletAnimationPos + i * 2 * Mathf.PI / 3) * bulletDis);
        }    
    }

    IEnumerator ableToMove()
    {
        yield return new WaitForSeconds(0.3f);
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.AddRelativeForce(new Vector3(0, 0, -speed * 30), ForceMode.Force);
    }
}