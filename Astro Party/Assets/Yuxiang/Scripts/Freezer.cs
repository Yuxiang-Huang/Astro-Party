using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public int id;
    public int team;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("selfDestruct");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pilot"))
        {
            if (collision.gameObject.GetComponent<PilotPlayerController>() != null)
            {
                collision.gameObject.GetComponent<PilotPlayerController>().kill(id, team);
            }
            else
            {
                collision.gameObject.GetComponent<BotPilotMove>().kill(id, team);
            }
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<MutualShip>().damage(id, team);
        }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
