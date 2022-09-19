using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBuilder : MonoBehaviour
{

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        int n = 8;

        float xPos = 10;
        float yPos = 10;

        float radius = 10;

        float averageAngle = 360 / n / 2;
        float hyp = 2 * radius / Mathf.Tan(averageAngle);

        for (int i = 0; i < n; i++)
        {
            float angle = 360 / n * i;

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
