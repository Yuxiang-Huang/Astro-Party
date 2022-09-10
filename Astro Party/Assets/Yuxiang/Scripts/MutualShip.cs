using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutualShip : MonoBehaviour
{
    public int id;
    public int team;

    public string shootMode;
    public bool tripleShot;

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

    public GameObject jousters;
    public GameObject sideCannons;
    public GameObject freezed;

    public Renderer rend;
    public Material blue1;
    public Material red2;
    public Material yellow3;
    public Material cyan4;
    public Material green5;

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

        jousters.SetActive(false);

        if (tripleShot)
        {
            sideCannons.SetActive(true);
        }
        else
        {
            sideCannons.SetActive(false);
        }

        freezed.SetActive(false);

        //setColor and control
        switch (id)
        {
            case 1:
                rend.material = blue1;
                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().turn = KeyCode.BackQuote;
                    GetComponent<PlayerController>().turn = KeyCode.Tab;
                }
                break;
            case 2:
                rend.material = red2;
                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().turn = KeyCode.Z;
                    GetComponent<PlayerController>().turn = KeyCode.X;
                }
                break;
            case 3:
                rend.material = yellow3;
                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().turn = KeyCode.T;
                    GetComponent<PlayerController>().turn = KeyCode.Y;
                }
                break;
            case 4:
                rend.material = cyan4;
                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().turn = KeyCode.O;
                    GetComponent<PlayerController>().turn = KeyCode.P;
                }
                break;
            case 5:
                rend.material = green5;
                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().turn = KeyCode.UpArrow;
                    GetComponent<PlayerController>().turn = KeyCode.DownArrow;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //keep y the same
        transform.position = new Vector3(transform.position.x, 10, transform.position.z);

        //regenerate ammo
        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
            reloadTime = Mathf.Max(reloadTime, 0);
            if (reloadTime == 0)
            {
                ammo++;
                if (shootMode == "normal")
                {
                    bulletAnimation[ammo - 1].SetActive(true);
                }
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

        if (shootMode == "normal" && ammo > 0)
        {
            ammo--;

            bulletAnimation[ammo].SetActive(false);

            if (reloadTime == 0)
            {
                reloadTime = 2;
            }

            //Debug.Log(Mathf.Cos(transform.rotation.y));
            //Debug.Log(Mathf.Sin(transform.rotation.y));

            if (tripleShot)
            {
                GameObject sideBullet1 = Instantiate(powerUpManagerScript.bullet, transform.position +
            new Vector3(bulletDis * Mathf.Sin(angle + 1), 20, bulletDis * Mathf.Cos(angle + 1)),
            transform.rotation);

                //setting the script varibles
                sideBullet1.GetComponent<BulletMove>().id = id;
                sideBullet1.GetComponent<BulletMove>().team = team;

                GameObject sideBullet2 = Instantiate(powerUpManagerScript.bullet, transform.position +
            new Vector3(bulletDis * Mathf.Sin(angle - 1), 20, bulletDis * Mathf.Cos(angle - 1)),
            transform.rotation);

                //setting the script varibles
                sideBullet2.GetComponent<BulletMove>().id = id;
                sideBullet2.GetComponent<BulletMove>().team = team;
            }

            GameObject myBullet = Instantiate(powerUpManagerScript.bullet, transform.position +
            new Vector3(bulletDis * Mathf.Sin(angle), 20, bulletDis * Mathf.Cos(angle)),
            transform.rotation);

            //setting the script varibles
            myBullet.GetComponent<BulletMove>().id = id;
            myBullet.GetComponent<BulletMove>().team = team;
            

            //Sound effect
            playerAudio.PlayOneShot(SEManagerScript.bulletSound);
        }
        else if (shootMode == "Laser Beam")
        {
            //5000 is half the length of laserbeam
            GameObject myLaser = Instantiate(powerUpManagerScript.laser, transform.position +
            new Vector3((bulletDis + 1000) * Mathf.Sin(angle), 10, (bulletDis + 1000) * Mathf.Cos(angle)),
            transform.rotation);

            //setting the script varibles
            myLaser.GetComponent<Laser>().id = id;
            myLaser.GetComponent<Laser>().team = team;

            //Sound effect
            playerAudio.PlayOneShot(SEManagerScript.laserSound);

            //Freeze after using laser
            StartCoroutine("laserFreeze");

            shootMode = "normal";

            ammo = 3;

            foreach (GameObject curr in bulletAnimation)
            {
                curr.SetActive(true);
            }
        }
        else if (shootMode == "Scatter Shot")
        {
            int numOfShots = 16;

            for (int i = 0; i < numOfShots; i++)
            {
                float angleNow = transform.rotation.ToEulerAngles().y;

                GameObject myBullet = Instantiate(powerUpManagerScript.bullet, transform.position +
            new Vector3(bulletDis * Mathf.Sin(angleNow), 20, bulletDis * Mathf.Cos(angleNow)), transform.rotation);

                transform.Rotate(0, 360 / numOfShots, 0);

                //Sound effect
                playerAudio.PlayOneShot(SEManagerScript.bulletSound);

                //setting the script varibles
                myBullet.GetComponent<BulletMove>().id = id;
                myBullet.GetComponent<BulletMove>().team = team;
            }

            shootMode = "normal";

            ammo = 3;

            foreach (GameObject curr in bulletAnimation)
            {
                curr.SetActive(true);
            }
        }
        else if (shootMode == "Freezer")
        {
            GameObject myFreezer = Instantiate(powerUpManagerScript.freezer, transform.position, transform.rotation);   

            //Sound effect
            playerAudio.PlayOneShot(SEManagerScript.freezerSound);

            //setting the script varibles
            myFreezer.GetComponent<Freezer>().id = id;
            myFreezer.GetComponent<Freezer>().team = team;

            shootMode = "normal";

            ammo = 3;

            foreach (GameObject curr in bulletAnimation)
            {
                curr.SetActive(true);
            }
        }
    }

    IEnumerator laserFreeze()
    {
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(0.3f);
        playerRb.constraints = RigidbodyConstraints.FreezeRotation;

        //not for bot
        if (GetComponent<PlayerController>() != null)
        {
            playerRb.AddRelativeForce(new Vector3(0, 0, -speed * 30), ForceMode.Force);
        }
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
            string powerUpName = other.gameObject.GetComponent<PowerUp>().powerUpName;
            if (powerUpName == "Triple Shot")
            {
                tripleShot = true;
                sideCannons.SetActive(true);
            }
            else
            {
                shootMode = powerUpName;

                foreach (GameObject curr in bulletAnimation)
                {
                    curr.SetActive(false);
                }
            }
        }

        gameManagerScript.inGameIndicators.Remove(other.gameObject);
        Destroy(other.gameObject);
    }
}
