using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portals;

    List<GameObject> portalList;

    // Start is called before the first frame update
    void Start()
    {
        portalList = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            portalList.Add(Instantiate(portals, generateRanPos(), portals.transform.rotation));
            portalList[i].transform.Rotate(0, Random.Range(0, 360), 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 generateRanPos()
    {
        int spawnRadius = 750 - 125;

        Vector3 ranPos = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0,
          Random.Range(-spawnRadius, spawnRadius));

        //outside the circle
        while (distance(ranPos, new Vector3(0, 0, 0)) > spawnRadius){
            ranPos = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0,
Random.Range(-spawnRadius, spawnRadius));
        }

        return ranPos;
    }

    float distance(Vector3 ship1, Vector3 ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.x - ship2.x), 2) + Mathf.Pow((ship1.z - ship2.z), 2));
    }
}
