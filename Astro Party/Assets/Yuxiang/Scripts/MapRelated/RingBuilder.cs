using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBuilder : MonoBehaviour
{

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        int n = 1000;

        float radius = 750;

        for (int i = 0; i < n; i++)
        {
            float angle = 2 * Mathf.PI / n * i;

            GameObject now = Instantiate(wall, new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle)),
                wall.transform.rotation);
            now.transform.Rotate(new Vector3(0, 180 * angle / Mathf.PI, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
