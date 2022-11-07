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
                spawnTime = Random.Range(1f, 2f);

                spawnHelper("up");
                spawnHelper("down");
                spawnHelper("left");
                spawnHelper("right");
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
    }

    void spawnHelper(string direction)
    {
        for (int i = -spawnLen; i < spawnLen; i += 100)
        {
            if (Random.Range(0, 16) == 0)
            {
                GameObject curr = Instantiate(fog, new Vector3(i, fogYvalue, spawnLen), fog.transform.rotation);
                switch (direction)
                {
                    case "up":
                        Destroy(curr);
                        curr = Instantiate(fog, new Vector3(i, fogYvalue, spawnLen), fog.transform.rotation);
                        break;
                    case "down":
                        Destroy(curr);
                        curr = Instantiate(fog, new Vector3(i, fogYvalue, -spawnLen), fog.transform.rotation);
                        break;
                    case "left":
                        Destroy(curr);
                        curr = Instantiate(fog, new Vector3(-spawnLen, fogYvalue, i), fog.transform.rotation);
                        break;
                    case "right":
                        Destroy(curr);
                        curr = Instantiate(fog, new Vector3(spawnLen, fogYvalue, i), fog.transform.rotation);
                        break;
                }

                curr.GetComponent<Fog>().direction = direction;
                curr.GetComponent<Fog>().speed = speed;
                curr.transform.parent = parent.transform;
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
