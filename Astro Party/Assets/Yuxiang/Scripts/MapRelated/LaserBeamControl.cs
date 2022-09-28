using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamControl : MonoBehaviour
{
    public int radius = 700;
    public GameObject indicator;
    public GameObject laserBeam;

    GameObject indicator1;
    GameObject indicator2;
    GameObject indicator3;
    GameObject indicator4;
    GameObject indicator5;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 endPoint1 = new Vector3(radius * Mathf.Cos(Mathf.PI / 10), 1, radius * Mathf.Sin(Mathf.PI / 10));
        Vector3 endPoint2 = new Vector3(radius * Mathf.Cos(Mathf.PI / 2), 1, radius * Mathf.Sin(Mathf.PI / 2));
        Vector3 endPoint3 = new Vector3(radius * Mathf.Cos(9 * Mathf.PI / 10), 1, radius * Mathf.Sin(9 * Mathf.PI / 10));
        Vector3 endPoint4 = new Vector3(radius * Mathf.Cos(13 * Mathf.PI / 10), 1, radius * Mathf.Sin(13 * Mathf.PI / 10));
        Vector3 endPoint5 = new Vector3(radius * Mathf.Cos(17 * Mathf.PI / 10), 1, radius * Mathf.Sin(17 * Mathf.PI / 10));

        //1 and 3
        indicator1 = Instantiate(indicator, new Vector3((endPoint1.x + endPoint3.x) / 2, 1, (endPoint1.z + endPoint3.z) / 2),
            transform.rotation);

        //1 and 4
        indicator2 = Instantiate(indicator, new Vector3((endPoint1.x + endPoint4.x) / 2, 1, (endPoint1.z + endPoint4.z) / 2),
            transform.rotation);
        indicator2.transform.Rotate(new Vector3 (0, -36, 0));

        //2 and 4
        indicator3 = Instantiate(indicator, new Vector3((endPoint2.x + endPoint4.x) / 2, 1, (endPoint2.z + endPoint4.z) / 2),
            transform.rotation);
        indicator3.transform.Rotate(new Vector3(0, 90 + 36 / 2, 0));

        //2 and 5
        indicator4 = Instantiate(indicator, new Vector3((endPoint2.x + endPoint5.x) / 2, 1, (endPoint2.z + endPoint5.z) / 2),
            transform.rotation);
        indicator4.transform.Rotate(new Vector3(0, 36 * 2, 0));

        //3 and 5
        indicator5 = Instantiate(indicator, new Vector3((endPoint3.x + endPoint5.x) / 2, 1, (endPoint3.z + endPoint5.z) / 2),
            transform.rotation);
        indicator5.transform.Rotate(new Vector3(0, 36, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
