using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portals;

    List<GameObject> portalParentList;
    List<GameObject> portalList;

    public Material blue1;
    public Material red2;
    public Material yellow3;
    public Material cyan4;
    public Material green5;

    // Start is called before the first frame update
    void Start()
    {
        portalParentList = new List<GameObject>();
        portalList = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            portalParentList.Add(Instantiate(portals, generateRanPos(), portals.transform.rotation));
            portalParentList[i].transform.Rotate(0, Random.Range(0, 360), 0);

            portalList.Add(portalParentList[i].GetComponent<PortalParent>().portal1);
            portalList.Add(portalParentList[i].GetComponent<PortalParent>().portal2);
        }

        int color = 1;

        while (portalList.Count > 0)
        {
            int ran = Random.Range(1, portalList.Count);

            portalList[0].GetComponent<Portal>().pair = portalList[ran];
            portalList[ran].GetComponent<Portal>().pair = portalList[0];

            switch (color)
            {
                case 1:
                    portalList[0].GetComponent<Portal>().rend.material = blue1;
                    portalList[ran].GetComponent<Portal>().rend.material = blue1;
                    break;
                case 2:
                    portalList[0].GetComponent<Portal>().rend.material = red2;
                    portalList[ran].GetComponent<Portal>().rend.material = red2;
                    break;
                case 3:
                    portalList[0].GetComponent<Portal>().rend.material = yellow3;
                    portalList[ran].GetComponent<Portal>().rend.material = yellow3;
                    break;
                case 4:
                    portalList[0].GetComponent<Portal>().rend.material = cyan4;
                    portalList[ran].GetComponent<Portal>().rend.material = cyan4;
                    break;
                case 5:
                    portalList[0].GetComponent<Portal>().rend.material = green5;
                    portalList[ran].GetComponent<Portal>().rend.material = green5;
                    break;
            }

            portalList.Remove(portalList[ran]);
            portalList.Remove(portalList[0]);

            color++;
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
