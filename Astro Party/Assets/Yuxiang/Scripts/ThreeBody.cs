using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBody : MonoBehaviour
{
    public GameObject otherOne;
    public GameObject otherTwo;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        rb.velocity += new Vector3 ( (otherOne.transform.position.x - transform.position.x) /
            Mathf.Pow(distance(otherOne.transform.position, transform.position), 2), 0,
            (otherOne.transform.position.z - transform.position.z) /
            Mathf.Pow(distance(otherOne.transform.position, transform.position), 2) );
    }

    float distance(Vector3 ship1, Vector3 ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.x - ship2.x), 2) +
            Mathf.Pow((ship1.z - ship2.z), 2));
    }
}
