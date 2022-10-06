using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    GameManager gameManagerScript;

    List<GameObject> allMaps = new List<GameObject>();

    int currMapID;

    public GameObject backButton;

    public GameObject Map1;
    public Text Map1Text;

    public GameObject Map2;
    public Text Map2Text;
    public List<GameObject> Map2rotatingObjects;

    public GameObject Map3;
    public Text Map3Text;
    public List<GameObject> Map3ThreeBodyObjects;

    public GameObject Map4;
    public Text Map4Text;

    public GameObject Map5;
    public Text Map5Text;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        Map1.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);
        Map4.SetActive(false);
        Map5.SetActive(false);

        allMaps.Add(Map1);
        //allMaps.Add(Map2);
        //allMaps.Add(Map3);
        //allMaps.Add(Map4);
        //allMaps.Add(Map5);
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
        //last map
        if (currMapID != 0)
        {
            foreach (GameObject currMap in allMaps)
            {
                if (currMap.GetComponent<Map>().mapID == currMapID)
                {
                    //foreach (GameObject curr in currMap.GetComponent<Map>().breakables)
                    //{
                    //    curr.SetActive(false);
                    //}
                    currMap.SetActive(false);
                }
            }
        }

        //next map
        GameObject map = allMaps[Random.Range(0, allMaps.Count)];

        currMapID = map.GetComponent<Map>().mapID;

        foreach (GameObject curr in map.GetComponent<Map>().breakables)
        {
            curr.SetActive(true);
        }
        map.SetActive(true);

        gameManagerScript.spawnRadius = map.GetComponent<Map>().radius;

        switch (currMapID)
        {
            case 1: reset1(); break;
            case 2: reset2(); break;
            case 3: reset3(); break;
            case 4: reset4(); break;
            case 5: reset5(); break;
        }
    }

    void reset1()
    {
        //nothing
    }

    void reset2()
    {
        foreach (GameObject curr in Map2rotatingObjects)
        {
            curr.GetComponent<MapRotation>().reset();
        }
    }

    void reset3()
    {
        foreach (GameObject curr in Map3ThreeBodyObjects)
        {
            curr.GetComponent<ThreeBody>().reset();
        }
    }

    void reset4()
    {
        Map4.GetComponent<LaserBeamControl>().reset();
    }

    void reset5()
    {
        Map5.GetComponent<SpiralBuilder>().reset();
    }

    public void Map1OnOff()
    {
        MapOnOffHelper(Map1, Map1Text);
    }

    public void Map2OnOff()
    {
        MapOnOffHelper(Map2, Map2Text);
    }

    public void Map3OnOff()
    {
        MapOnOffHelper(Map3, Map3Text);
    }

    public void Map4OnOff()
    {
        MapOnOffHelper(Map4, Map4Text);
    }

    public void Map5OnOff()
    {
        MapOnOffHelper(Map5, Map5Text);
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
