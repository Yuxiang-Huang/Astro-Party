using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    int myID;

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

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        shootMode = "laser";

        myID = GetComponent<ID>().id;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = this.gameObject;
        float minDistance = 10000;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            if (! shipList.Contains(this.gameObject))
            {
                foreach (GameObject ship in shipList)
                {
                    if (ship != this.gameObject)
                    {
                        if (distance(ship, this.gameObject) < minDistance)
                        {
                            target = ship;
                        }
                    }
                }
            }    
        }

        agent.SetDestination(target.transform.position);

        if (reloadTime == 0)
        {

            reloadTime = 2;

            float angle = transform.rotation.ToEulerAngles().y;

            if (shootMode == "laser")
            {
                //5000 is half the length of laserbeam
                GameObject myLaser = Instantiate(laser, transform.position +
                new Vector3((bulletDis + 5000) * Mathf.Sin(angle), 0, (bulletDis + 5000) * Mathf.Cos(angle)),
                transform.rotation);
                myLaser.GetComponent<Laser>().id = myID;

                playerAudio.PlayOneShot(laserSound);

                playerRb.constraints = RigidbodyConstraints.FreezePosition;

                StartCoroutine("ableToMove");

                shootMode = "normal";
            }

            if (shootMode == "normal")
            {
                GameObject myBullet = Instantiate(bullet, transform.position +
                new Vector3(bulletDis * Mathf.Sin(angle), 0, bulletDis * Mathf.Cos(angle)),
                transform.rotation);
                myBullet.GetComponent<BulletMove>().id = myID;
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

    float distance(GameObject ship1, GameObject ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.transform.position.x - ship2.transform.position.x), 2) +
            Mathf.Pow((ship1.transform.position.z - ship2.transform.position.z), 2));   
    }

    IEnumerator ableToMove()
    {
        yield return new WaitForSeconds(0.3f);
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.AddRelativeForce(new Vector3(0, 0, -speed * 30), ForceMode.Force);
    }
}
