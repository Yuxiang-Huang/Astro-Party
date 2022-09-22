using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    //[SerializeField] public NavMeshAgent agent;

    float botReloadTime;

    GameManager gameManagerScript;

    float traceTime;

    public bool disable;

    int speed = 500;
    int maxVelocity = 300;
    Rigidbody rb;

    public float threshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disable)
        {
            GameObject target = this.gameObject;
            float minDistance = 10000;

            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                if (!shipList.Contains(this.gameObject))
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

            //moving
            rb.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Force);

            if (rb.velocity.magnitude > maxVelocity)
            {
                rb.velocity = rb.velocity.normalized * maxVelocity;
            }

            //rotating
            //Debug.Log(Mathf.Atan2(target.transform.position.z - transform.position.z,
            //    target.transform.position.x - transform.position.x));
            //Debug.Log(transform.rotation.ToEulerAngles().y);

            transform.LookAt(target.transform);

            //shooting
            botReloadTime += Time.deltaTime;

            if (botReloadTime >= 1)
            {
                botReloadTime = 0;
                GetComponent<MutualShip>().shoot();
            }

            //Debug.Log(target.transform.position);

            //Can't trace too frequently
            //if (traceTime <= 0)
            //{
            //    agent.SetDestination(target.transform.position);
            //    traceTime = 0.5f;
            //}
            //if (traceTime > 0)
            //{
            //    traceTime -= Time.deltaTime;
            //}
        }
    }

    float distance(GameObject ship1, GameObject ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.transform.position.x - ship2.transform.position.x), 2) +
            Mathf.Pow((ship1.transform.position.z - ship2.transform.position.z), 2));
    }
}