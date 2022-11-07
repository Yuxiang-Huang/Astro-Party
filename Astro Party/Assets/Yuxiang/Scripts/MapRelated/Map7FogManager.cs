using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map7FogManager : MonoBehaviour
{
    public GameObject parent;

    public GameObject fog;

    public int spawnLen;
    public int speed;
    float fogYvalue = 90;

    bool started;

    float spawnTime;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        reset();

        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (spawnTime <= 0)
            {
                spawnTime = waitTime;

                for (int x = -spawnLen; x < spawnLen; x += 100)
                {
                    if (Random.Range(0, 8) == 0)
                    { 
                        GameObject curr = Instantiate(fog, new Vector3(x, fogYvalue, spawnLen), fog.transform.rotation);
                        curr.GetComponent<Fog>().direction = 4;
                        curr.GetComponent<Fog>().speed = speed;
                        curr.transform.parent = parent.transform;
                    }
                }
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
    }

    public void reset()
    {
        started = true;

        Destroy(parent);
        parent = new GameObject();

        //for (int i = -spawnLen; i <= spawnLen; i += 100)
        //{
        //    for (int j = -spawnLen; j <= spawnLen; j += 100)
        //    {
        //            GameObject curr = Instantiate(fog, new Vector3(i, fogyValue, j), fog.transform.rotation);
        //            curr.transform.parent = parent.transform;

        //    }
        //}
        //started = false;   
    }
}
