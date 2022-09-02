using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotPilotMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int[] corners = new int[4];

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            if (!shipList.Contains(this.gameObject))
            {
                foreach (GameObject ship in shipList)
                {
                    if (ship != this.gameObject)
                    {
                        if (ship.transform.position.x > gameManagerScript.spawnX / 2)
                        {
                            if (ship.transform.position.z > gameManagerScript.spawnZ / 2)
                            {
                                corners[0]++;
                            }
                            else
                            {
                                corners[4]++;
                            }
                        }
                        else
                        {
                            if (ship.transform.position.x > gameManagerScript.spawnX / 2)
                            {
                                if (ship.transform.position.z > gameManagerScript.spawnZ / 2)
                                {
                                    corners[2]++;
                                }
                                else
                                {
                                    corners[3]++;
                                }
                            }
                        }
                    }
                }
            }
        }

        Vector3 target = transform.position;

        if (corners[0] == 0)
        {
            target = new Vector3(gameManagerScript.spawnX, transform.position.y, gameManagerScript.spawnZ);
        }

        if (corners[1] == 0)
        {
            target = new Vector3(-gameManagerScript.spawnX, transform.position.y, gameManagerScript.spawnZ);
        }

        if (corners[2] == 0)
        {
            target = new Vector3(-gameManagerScript.spawnX, transform.position.y, -gameManagerScript.spawnZ);
        }

        if (corners[3] == 0)
        {
            target = new Vector3(gameManagerScript.spawnX, transform.position.y, -gameManagerScript.spawnZ);
        }

        Debug.Log(target);
        agent.SetDestination(target);
    }
}
