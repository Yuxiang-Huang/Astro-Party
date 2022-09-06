using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutualShip : MonoBehaviour
{
    public int id;
    public int team;

    public string shootMode;

    int speed = 500;
    int bulletDis = 75;
    public float bulletAnimationPos;
    public GameObject[] bulletAnimation;
    public float reloadTime;
    public int ammo;

    Rigidbody playerRb;
    AudioSource playerAudio;

    ScoreManager scoreManagerScript;
    GameManager gameManagerScript;
    PowerUpManager powerUpManagerScript;
    SEManager SEManagerScript;

    public GameObject pilot;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        if (shootMode == "")
        {
            shootMode = "normal";
        }
        else
        {
            foreach (GameObject curr in bulletAnimation)
            {
                curr.SetActive(false);
            }
        }

        ammo = 3;

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        powerUpManagerScript = GameObject.Find("PowerUp Manager").GetComponent<PowerUpManager>();
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();

        StartCoroutine("beginFreeze");
    }

    // Update is called once per frame
    void Update()
    {
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

        bulletAnimationPos += Time.deltaTime;

        for (int i = 0; i < bulletAnimation.Length; i++)
        {
            bulletAnimation[i].transform.position = new Vector3(transform.position.x +
                Mathf.Cos(bulletAnimationPos + i * 2 * Mathf.PI / 3) * bulletDis,
                transform.position.y, transform.position.z + Mathf.Sin(bulletAnimationPos + i * 2 * Mathf.PI / 3) * bulletDis);
        }
    }

    public void shoot()
    {
        float angle = transform.rotation.ToEulerAngles().y;

        if (shootMode == "Laser Beam")
        {
            //5000 is half the length of laserbeam
            GameObject myLaser = Instantiate(powerUpManagerScript.laser, transform.position +
            new Vector3((bulletDis + 5000) * Mathf.Sin(angle), 0, (bulletDis + 5000) * Mathf.Cos(angle)),
            transform.rotation);

            //setting the script varibles
            myLaser.GetComponent<Laser>().id = id;
            myLaser.GetComponent<Laser>().team = team;

            //Sound effect
            playerAudio.PlayOneShot(SEManagerScript.laserSound);

            //Freeze after using laser
            StartCoroutine("laserFreeze");

            shootMode = "normal";

            foreach (GameObject curr in bulletAnimation)
            {
                curr.SetActive(true);
            }
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

            GameObject myBullet = Instantiate(powerUpManagerScript.bullet, transform.position +
            new Vector3(bulletDis * Mathf.Sin(angle), 0, bulletDis * Mathf.Cos(angle)),
            transform.rotation);

            //Sound effect
            playerAudio.PlayOneShot(SEManagerScript.bulletSound);

            //setting the script varibles
            myBullet.GetComponent<BulletMove>().id = id;
            myBullet.GetComponent<BulletMove>().team = team;
        }
    }

    IEnumerator laserFreeze()
    {
        playerRb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(0.3f);
        playerRb.constraints = RigidbodyConstraints.FreezePositionY;
        playerRb.AddRelativeForce(new Vector3(0, 0, -speed * 30), ForceMode.Force);
    }

    IEnumerator beginFreeze()
    {
        playerRb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(3f);
        playerRb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    public void spawnPilot()
    {
        GameObject myPilot = Instantiate(pilot, transform.position, transform.rotation);
        myPilot.transform.Rotate(90, 0, 0);
        if (myPilot.GetComponent<PilotPlayerController>() != null)
        {
            myPilot.GetComponent<PilotPlayerController>().turn = GetComponent<PlayerController>().turn;
            myPilot.GetComponent<PilotPlayerController>().move = GetComponent<PlayerController>().shoot;
            myPilot.GetComponent<PilotPlayerController>().StartCoroutine("respawn");
            myPilot.GetComponent<PilotPlayerController>().team = team;
        } else if (myPilot.GetComponent<BotPilotMove>() != null)
        {
            myPilot.GetComponent<BotPilotMove>().StartCoroutine("respawn");
            myPilot.GetComponent<BotPilotMove>().team = team;
        }

        gameManagerScript.inGameShips[team].Add(myPilot);
        

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pilot"))
        {
            bool toKill = true;

            //Friendly Fire 
            if (!scoreManagerScript.friendlyFire)
            {
                if(collision.gameObject.GetComponent<PilotPlayerController>() != null)
                {
                    if (team == collision.gameObject.GetComponent<PilotPlayerController>().team)
                    {
                        toKill = false;
                    }
                }

                else if (collision.gameObject.GetComponent<BotPilotMove>() != null)
                {
                    if (team == collision.gameObject.GetComponent<BotPilotMove>().team)
                    {
                        toKill = false;
                    }
                }
            }
            if (toKill)
            {
                SEManagerScript.generalAudio.PlayOneShot(SEManagerScript.pilotDeath);

                Destroy(collision.gameObject);
                if (scoreManagerScript.shipMode == "pilot")
                {
                    earnPoint();
                }
            }
        }
    }

    void earnPoint()
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            shootMode = other.gameObject.GetComponent<PowerUp>().powerUpName;

            foreach (GameObject curr in bulletAnimation)
            {
                curr.SetActive(false);
            }
        }

        gameManagerScript.inGameIndicators.Remove(other.gameObject);
        Destroy(other.gameObject);
    }
}
