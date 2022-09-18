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

    public GameObject Map3;
    public Text Map3Text;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

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
        //last map
        if (currMapID != 0)
        {
            foreach (GameObject currMap in allMaps)
            {
                if (currMap.GetComponent<Map>().mapID == currMapID)
                {
                    foreach (GameObject curr in currMap.GetComponent<Map>().breakables)
                    {
                        curr.SetActive(false);
                    }
                    Map2.SetActive(false);
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

        gameManagerScript.spawnX = map.GetComponent<Map>().xSpawn;
        gameManagerScript.spawnZ = map.GetComponent<Map>().zSpawn;
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
