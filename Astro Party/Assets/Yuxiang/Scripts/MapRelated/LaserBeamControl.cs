using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamControl : MonoBehaviour
{
    public int radius = 700;
    public GameObject indicator;
    public GameObject laserBeam;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 endPoint1 = new Vector3(radius * Mathf.Cos(Mathf.PI / 10), 1, radius * Mathf.Sin(Mathf.PI / 10));
        Vector3 endPoint2 = new Vector3(radius * Mathf.Cos(9 * Mathf.PI / 10), 1, radius * Mathf.Sin(9 * Mathf.PI / 10));

        Debug.Log(endPoint1);
        Debug.Log(endPoint2);

        Instantiate(indicator, new Vector3((endPoint1.x + endPoint2.x) / 2, 1, (endPoint1.z + endPoint2.z) / 2),
            transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
