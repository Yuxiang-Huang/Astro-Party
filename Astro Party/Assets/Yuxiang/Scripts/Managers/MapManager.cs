using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    GameManager gameManagerScript;
    CameraManager cameraMangerScript;

    List<GameObject> currMaps = new List<GameObject>();
    List<GameObject> allMaps = new List<GameObject>();
    List<Text> allText = new List<Text>();

    bool allChange;
    public Text allChangeText;

    int currMapID;

    public GameObject backButton;

    public GameObject Map0;
    public Text Map0Text;

    public GameObject Map1;
    public Text Map1Text;
    public GameObject Map1rotatingInner;
    public GameObject Map1rotatingOuter;

    public GameObject Map2;
    public Text Map2Text;
    public List<GameObject> Map2rotatingObjects;
    public int velocity;
    public int velocity2;

    public GameObject Map3;
    public Text Map3Text;
    public List<GameObject> Map3ThreeBodyObjects;

    public GameObject Map4;
    public Text Map4Text;

    public GameObject Map5;
    public Text Map5Text;

    public GameObject Map6;
    public Text Map6Text;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cameraMangerScript = GameObject.Find("Main Camera").GetComponent<CameraManager>();

        Map0.SetActive(false);
        Map1.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);
        Map4.SetActive(false);
        Map5.SetActive(false);
        Map6.SetActive(false);

        allMaps.Add(Map0);
        allMaps.Add(Map1);
        allMaps.Add(Map2);
        allMaps.Add(Map3);
        allMaps.Add(Map4);
        allMaps.Add(Map5);
        allMaps.Add(Map6);

        foreach (GameObject map in allMaps)
        {
            currMaps.Add(map);
        }

        allText.Add(Map0Text);
        allText.Add(Map1Text);
        allText.Add(Map2Text);
        allText.Add(Map3Text);
        allText.Add(Map4Text);
        allText.Add(Map5Text);
        allText.Add(Map6Text);
    }

    void Update()
    {
        if (currMaps.Count == 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }
    }

    public void resetMapNotNext()
    {
        if (currMapID != 0)
        {
            foreach (GameObject currMap in currMaps)
            {
                if (currMap.GetComponent<Map>().mapID == currMapID)
                {
                    currMap.SetActive(false);
                }
            }
        }
    }

    public void resetMap()
    {
        //last map off
        if (currMapID != 0)
        {
            foreach (GameObject currMap in currMaps)
            {
                if (currMap.GetComponent<Map>().mapID == currMapID)
                {
                    currMap.SetActive(false);
                }
            }
        }

        //next map
        GameObject map = currMaps[Random.Range(0, currMaps.Count)];

        currMapID = map.GetComponent<Map>().mapID;

        foreach (GameObject curr in map.GetComponent<Map>().breakables)
        {
            curr.SetActive(true);
        }
        map.SetActive(true);

        gameManagerScript.spawnRadius = map.GetComponent<Map>().radius;

        //call function
        switch (currMapID)
        {
            case 0: reset0(); break;
            case 1: reset1(); break;
            case 2: reset2(); break;
            case 3: reset3(); break;
            case 4: reset4(); break;
            case 5: reset5(); break;
            case 6: reset6(); break;
        }
    }


    public void AllChange()
    {
        if (allChange)
        {
            //all on
            while (currMaps.Count > 0)
            {
                currMaps.RemoveAt(0);
            }

            foreach (GameObject map in allMaps)
            {
                currMaps.Add(map);
            }

            foreach (Text mapText in allText)
            {
                mapText.text = "On";
            }
            allChangeText.text = "All Off";
        }
        else
        {
            //all off
            while (currMaps.Count > 0)
            {
                currMaps.RemoveAt(0);
            }

            foreach (Text mapText in allText)
            {
                mapText.text = "Off";
            }
            allChangeText.text = "All On";
        }
        allChange = !allChange;
    }

    void reset0()
    {
        //nothing
    }

    void reset1()
    {
        float posV = Random.Range(0.5f, 1.5f);
        float negV = -Random.Range(0.5f, 1.5f);

        if (Random.Range(0, 2) == 0)
        {
            Map1rotatingInner.GetComponent<Map1RotatingObject>().velocity = negV;
            Map1rotatingOuter.GetComponent<Map1RotatingObject>().velocity = posV;
        }
        else
        {
            Map1rotatingInner.GetComponent<Map1RotatingObject>().velocity = posV;
            Map1rotatingOuter.GetComponent<Map1RotatingObject>().velocity = negV;

        }
    }

    void reset2()
    {
        velocity = Random.Range(125, 175);
        velocity2 = Random.Range(75, 125);

        foreach (GameObject curr in Map2rotatingObjects)
        {
            curr.GetComponent<Map2CircularMotion>().reset();
            curr.GetComponent<Map2CircularMotion>().velocity = velocity2;
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

    void reset6()
    {
        Map6.GetComponent<PortalManager>().reset();
        //fix camera for map6
        cameraMangerScript.startLock = true;
    }

    public void Map0OnOff()
    {
        MapOnOffHelper(Map0, Map0Text);
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

    public void Map6OnOff()
    {
        MapOnOffHelper(Map6, Map6Text);
    }

    void MapOnOffHelper(GameObject map, Text mapText)
    {
        if (currMaps.Contains(map))
        {
            currMaps.Remove(map);
            mapText.text = "Off";
        }
        else
        {
            currMaps.Add(map);
            mapText.text = "On";
        }
    }
}
