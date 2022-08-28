using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    int speed = 350;
    float rotatingSpeed = 1.5f;
    bool rotating;
    int bulletDis = 75;

    public float reloadTime;

    public string shootMode;
    //normal, laser

    public AudioClip laserSound;

    public GameObject laser;
    public GameObject bullet;
    public GameObject[] bulletAnimation;

    Rigidbody playerRb;
    AudioSource playerAudio;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        shootMode = "laser";

        player = GameObject.Find("Player Red");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (reloadTime == 0)
        {

            reloadTime = 2;

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

            if (shootMode == "normal")
            {
                Instantiate(bullet, transform.position +
                new Vector3(bulletDis * Mathf.Sin(angle), 0, bulletDis * Mathf.Cos(angle)),
                transform.rotation);
            }
        }


        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
            reloadTime = Mathf.Max(reloadTime, 0);
        }

        if (rotating && playerRb.constraints != RigidbodyConstraints.FreezePosition)
        {
            playerRb.freezeRotation = false;
            transform.Rotate(0, rotatingSpeed, 0);
            playerRb.freezeRotation = true;
        }
    }

    IEnumerator ableToMove()
    {
        yield return new WaitForSeconds(0.3f);
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.AddRelativeForce(new Vector3(0, 0, -speed * 30), ForceMode.Force);
    }
}
