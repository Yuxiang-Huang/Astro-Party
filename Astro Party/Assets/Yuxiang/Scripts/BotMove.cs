using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;

    public float botReloadTime;

    GameManager gameManagerScript;

    float traceTime;

    public bool disable;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

            //Debug.Log(target.transform.position);

            //Can't trace too frequently
            if (traceTime <= 0)
            {
                agent.SetDestination(target.transform.position);
                traceTime = 0.5f;
            }
            if (traceTime > 0)
            {
                traceTime -= Time.deltaTime;
            }

            if (botReloadTime > 0)
            {
                botReloadTime -= Time.deltaTime;
                botReloadTime = Mathf.Max(botReloadTime, 0);
            }

            if (botReloadTime == 0)
            {
                botReloadTime = 1;
                GetComponent<MutualShip>().shoot();
            }
        }
    }

    float distance(GameObject ship1, GameObject ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.transform.position.x - ship2.transform.position.x), 2) +
            Mathf.Pow((ship1.transform.position.z - ship2.transform.position.z), 2));
    }
}