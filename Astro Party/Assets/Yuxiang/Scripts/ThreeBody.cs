using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBody : MonoBehaviour
{
    public GameObject otherOne;
    public GameObject otherTwo;
    Rigidbody rb;

    public float G;

    public int spawnRange;
    public int randomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reset();
    }

    // Update is called once per frame
    void Update()
    { 
        rb.velocity += new Vector3 ( (otherOne.transform.position.x - transform.position.x) /
            Mathf.Pow(distance(otherOne.transform.position, transform.position), 2) * G, 0,
            (otherOne.transform.position.z - transform.position.z) /
            Mathf.Pow(distance(otherOne.transform.position, transform.position), 2) * G);
    }

    float distance(Vector3 ship1, Vector3 ship2)
    {
        return Mathf.Sqrt(Mathf.Pow((ship1.x - ship2.x), 2) +
            Mathf.Pow((ship1.z - ship2.z), 2));
    }

    public void reset()
    {
        transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
        rb.velocity = new Vector3(Random.Range(-randomSpeed, randomSpeed), 0, Random.Range(-randomSpeed, randomSpeed));
    }
}
