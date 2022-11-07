using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map7FogManager : MonoBehaviour
{
    public GameObject parent;

    public GameObject fog;

    public int spawnLen = 800;

    public float fogyValue = 90;

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
        Destroy(parent);
        parent = new GameObject();

        for (int i = -spawnLen; i <= spawnLen; i += 100)
        {
            for (int j = -spawnLen; j <= spawnLen; j += 100)
            {
                GameObject curr = Instantiate(fog, new Vector3(i, fogyValue, j), fog.transform.rotation);
                curr.transform.parent = parent.transform;
            }
        }
    }
}
