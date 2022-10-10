using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject prepScreen;
    public GameObject directionScreen;

    public GameObject playerShip;

    public List<GameObject> ships;
    public GameObject tutorialMap;

    public TextMeshProUGUI direction0;
    public TextMeshProUGUI direction1;

    // Start is called before the first frame update
    void Start()
    {
        prepScreen.SetActive(false);
        directionScreen.SetActive(false);

        GameObject shipPlayer = Instantiate(playerShip, new Vector3(0, 10, 0),
    playerShip.transform.rotation);
        shipPlayer.SetActive(false);

        ships.Add(shipPlayer);

        direction0.gameObject.SetActive(false);
        direction1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prep()
    {
        startScreen.SetActive(false);
        prepScreen.SetActive(true);
    }

    public void backToStart()
    {
        prepScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void startTutorial()
    {
        prepScreen.SetActive(false);
        tutorialMap.SetActive(true);
        ships[0].SetActive(true);
        directionScreen.SetActive(true);
        direction0.gameObject.SetActive(true);
    }

    public void directionSwitch()
    {
        if (direction0.gameObject.activeSelf)
        {
            direction0.gameObject.SetActive(false);
            direction1.gameObject.SetActive(true);
        }
    }
}
