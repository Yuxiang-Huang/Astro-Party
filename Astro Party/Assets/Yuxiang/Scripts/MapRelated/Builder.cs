using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    public GameObject borderWall;

    public GameObject wall;
    public GameObject breakableWall;

    // Start is called before the first frame update
    void Start()
    {
        map5Build();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ringBuild()
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

    public void map5Build()
    {

        Instantiate(pick(), new Vector3(0, 0, 50), transform.rotation);

        int times = 2;
        for (int x = 0; x < times; x++)
        {
            
        }
    }

    GameObject pick()
    {
        if (Random.Range(0, 2) == 0)
        {
            return wall;
        }
        else
        {
            return breakableWall;
        }
    }
}
