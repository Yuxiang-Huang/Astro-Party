using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map7FogManager : MonoBehaviour
{
    public List<GameObject> allFogs;

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
                GameObject curr = new GameObject();
                switch (direction)
                {
                    case "up":
                        curr = Instantiate(fog, new Vector3(i, fogYvalue, spawnLen), fog.transform.rotation);
                        break;
                    case "down":
                        curr = Instantiate(fog, new Vector3(i, fogYvalue, -spawnLen), fog.transform.rotation);
                        break;
                    case "left":
                        curr = Instantiate(fog, new Vector3(-spawnLen, fogYvalue, i), fog.transform.rotation);
                        break;
                    case "right":
                        curr = Instantiate(fog, new Vector3(spawnLen, fogYvalue, i), fog.transform.rotation);
                        break;
                }

                curr.GetComponent<Fog>().direction = direction;
                curr.GetComponent<Fog>().speed = speed;
                allFogs.Add(curr);
            }
        }
    }

    public void reset()
    {
        started = true;

        while (allFogs.Count > 0)
        {
            Destroy(allFogs[0]);
            allFogs.RemoveAt(0);
        }

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
