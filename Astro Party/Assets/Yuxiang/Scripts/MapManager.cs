using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    int mapId;
    int maxMapId = 2;

    public List<GameObject> Map1;
    public List<GameObject> Map2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void resetMap()
    {
        if (mapId != 0)
        {
            switch (mapId)
            {
                case 1: resetMap1(false); break;
                case 2: resetMap2(false); break;
            }
        }

        mapId = Random.Range(1, maxMapId + 1);
        //Debug.Log(mapId);

        switch (mapId)
        {
            case 1: resetMap1(true); break;
            case 2: resetMap2(true); break;
        }
    }

    void resetMap1(bool status)
    {
        foreach (GameObject curr in Map1)
        {
            curr.SetActive(status);
        }
    }

    void resetMap2(bool status)
    {
        foreach (GameObject curr in Map2)
        {
            curr.SetActive(status);
        }
    }
}
