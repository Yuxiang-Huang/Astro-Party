using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralBuilder : MonoBehaviour
{
    public GameObject wall;
    public GameObject breakableWall;

    GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset()
    {
        Destroy(p);

        p = new GameObject();

        p.transform.position = new Vector3(0, 0, 0);

        Vector3 curr = new Vector3(0, 0, 0);

        //special first

        GameObject now1 = Instantiate(breakableWall, curr, transform.rotation);
        now1.transform.SetParent(p.transform);

        curr = new Vector3(curr.x + 100, curr.y, curr.z);

        GameObject now2 = Instantiate(breakableWall, curr, transform.rotation);
        now2.transform.SetParent(p.transform);

        int times = 10;

        for (int x = 2; x < times; x++)
        {
            for (int i = 0; i < x; i++)
            {
                //down
                if (x % 4 == 2)
                {
                    curr = new Vector3(curr.x, curr.y, curr.z - 100);
                }

                //left
                if (x % 4 == 3)
                {
                    curr = new Vector3(curr.x - 100, curr.y, curr.z);
                }

                //up
                if (x % 4 == 0)
                {
                    curr = new Vector3(curr.x, curr.y, curr.z + 100);
                }

                //right
                if (x % 4 == 1)
                {
                    curr = new Vector3(curr.x + 100, curr.y, curr.z);
                }

                GameObject now = Instantiate(pick(), curr, transform.rotation);
                now.transform.SetParent(p.transform);
            }
        }

        //special last 
        for (int i = 0; i < 8; i++)
        {
            curr = new Vector3(curr.x, curr.y, curr.z - 100);
            GameObject now = Instantiate(pick(), curr, transform.rotation);
            now.transform.SetParent(p.transform);
        }

        p.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
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
