using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    int mapId;

    public List<GameObject> Map2;

    // Start is called before the first frame update
    void Start()
    {
        mapId = 2;
    }

    public void resetMap()
    {
        switch (mapId)
        {
            case 2: resetMap2(); break;
        }
    }

    public void resetMap2()
    {
        foreach (GameObject curr in Map2)
        {
            curr.SetActive(true);
        }
    }
}
