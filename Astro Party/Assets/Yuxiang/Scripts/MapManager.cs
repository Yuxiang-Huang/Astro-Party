using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    List<GameObject> allMaps = new List<GameObject>();

    int mapId;

    public GameObject backButton;

    public GameObject Map1;
    public Text Map1Text;
    public List<GameObject> Map1Objects;

    public GameObject Map2;
    public Text Map2Text;
    public List<GameObject> Map2Objects;

    // Start is called before the first frame update
    void Start()
    {
        allMaps.Add(Map1);
        allMaps.Add(Map2);
    }

    void Update()
    {
        if (allMaps.Count == 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }
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

        GameObject map = allMaps[Random.Range(0, allMaps.Count)];

        if (map == Map1)
        {
            mapId = 1;
        }

        if (map == Map2)
        {
            mapId = 2;
        }

        //Debug.Log(map);
        //Debug.Log(mapId);

        switch (mapId)
        {
            case 1: resetMap1(true); break;
            case 2: resetMap2(true); break;
        }
    }

    void resetMap1(bool status)
    {
        foreach (GameObject curr in Map1Objects)
        {
            curr.SetActive(status);
        }
        Map1.SetActive(status);
    }

    void resetMap2(bool status)
    {
        foreach (GameObject curr in Map2Objects)
        {
            curr.SetActive(status);
        }
        Map2.SetActive(status);
    }

    public void Map1OnOff()
    {
        MapOnOffHelper(Map1, Map1Text);
    }

    public void Map2OnOff()
    {
        MapOnOffHelper(Map2, Map2Text);
    }

    void MapOnOffHelper(GameObject map, Text mapText)
    {
        if (allMaps.Contains(map))
        {
            allMaps.Remove(map);
            mapText.text = "Off";
        }
        else
        {
            allMaps.Add(map);
            mapText.text = "On";
        }
    }
}
