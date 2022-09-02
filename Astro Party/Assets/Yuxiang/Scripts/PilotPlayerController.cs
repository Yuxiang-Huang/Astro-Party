using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotPlayerController : MonoBehaviour
{
    int myID;
    public int team;

    public int speed = 30;
    float rotatingSpeed = 3f;
    bool rotating;
    bool moving;

    public KeyCode turn = KeyCode.A;
    public KeyCode move = KeyCode.D;

    Rigidbody playerRb;
    public int maxVelocity = 100;

    public GameObject ship;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            playerRb.AddRelativeForce(new Vector3(0, speed, 0), ForceMode.Force);
        }
        if (playerRb.velocity.magnitude > maxVelocity)
        {
            //Debug.Log(playerRb.velocity);
            playerRb.velocity = playerRb.velocity.normalized * maxVelocity;
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
            transform.Rotate(0, 0, rotatingSpeed);
            playerRb.freezeRotation = true;
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(3f);
        GameObject myShip = Instantiate(ship, transform.position, ship.transform.rotation);

        gameManagerScript.inGameShips[GetComponent<ID>().team].Add(myShip);
        gameManagerScript.inGameShips[GetComponent<ID>().team].Remove(this.gameObject);

        Destroy(this.gameObject);
    }
}
