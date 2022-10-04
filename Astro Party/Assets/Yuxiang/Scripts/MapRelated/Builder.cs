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

        Vector3 curr = new Vector3(0, 0, 50);

        for (int i = 0; i < 2; i++)
        {
            curr = new Vector3(curr.x + 100, curr.y, curr.z);

            Instantiate(pick(), curr, transform.rotation);
        }

        int times = 9;

        for (int x = 2; x < times; x++)
        {
            //down
            if (x % 4 == 2)
            {
                for (int i = 0; i < x; i++)
                {
                    curr = new Vector3(curr.x, curr.y, curr.z - 100);

                    Instantiate(pick(), curr, transform.rotation);
                }
            }

            //left
            if (x % 4 == 3)
            {
                for (int i = 0; i < x; i++)
                {
                    curr = new Vector3(curr.x - 100, curr.y, curr.z);

                    Instantiate(pick(), curr, transform.rotation);
                }
            }

            //up
            if (x % 4 == 0)
            {
                for (int i = 0; i < x; i++)
                {
                    curr = new Vector3(curr.x, curr.y, curr.z + 100);

                    Instantiate(pick(), curr, transform.rotation);
                }
            }

            //right
            if (x % 4 == 1)
            {
                for (int i = 0; i < x; i++)
                {
                    curr = new Vector3(curr.x + 100, curr.y, curr.z);

                    Instantiate(pick(), curr, transform.rotation);
                }
            }
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
