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

    public int spawnRadius = 500;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pivot = new GameObject ();
        pivot.transform.position = new Vector3(0, 0, 0);

        portalParentList = new List<GameObject>();
        portalList = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            portalParentList.Add(Instantiate(portals,
                new Vector3(Mathf.Cos(i * 2 * Mathf.PI / 5) * spawnRadius, 0, Mathf.Sin(i * 2 * Mathf.PI / 5) * spawnRadius),
                portals.transform.rotation));

            portalParentList[i].transform.Rotate(0, Random.Range(0, 360), 0);

            portalParentList[i].transform.parent = pivot.transform;

            portalList.Add(portalParentList[i].GetComponent<PortalParent>().portal1);
            portalList.Add(portalParentList[i].GetComponent<PortalParent>().portal2);
        }

        pivot.transform.Rotate(0, Random.Range(0, 360), 0);

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
}
