using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBuilder : MonoBehaviour
{

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        int n = 100;

        float xPos = 10;
        float yPos = 10;

        for (int i = 0; i < n; i++)
        {
            float angle = 2 * Mathf.PI / n * i;

            GameObject now = Instantiate(wall, new Vector3(xPos, 0, yPos), transform.rotation);
            now.transform.Rotate(new Vector3(0, angle, 0));

            xPos += 10;
            yPos += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
