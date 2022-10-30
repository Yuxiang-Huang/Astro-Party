using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    Rigidbody rb;

    public float velocity;
    public float radius;

    public int mode;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //F = m v^2 / r
        rb.AddForce((new Vector3(0, 0, 0) - transform.position).normalized * rb.mass * velocity * velocity / radius);
        rb.velocity = rb.velocity.normalized * velocity;
    }

    public void reset()
    {
        velocity = Random.Range(50, 100);
        switch (mode)
        {
            case 0:
                transform.position = new Vector3(400, 0, 0);
                rb.velocity = new Vector3(0, 0, velocity);
                break;
            case 1:
                rb.velocity = new Vector3(0, 0, -velocity);
                break;
            case 2:
                rb.velocity = new Vector3(-velocity, 0, velocity);
                break;
            case 3:
                rb.velocity = new Vector3(0, 0, velocity);
                break;
        }
    }
}
