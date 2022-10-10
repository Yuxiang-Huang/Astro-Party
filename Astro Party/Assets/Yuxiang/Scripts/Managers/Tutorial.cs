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
    public GameObject endScreen;

    public GameObject playerShip;

    public List<GameObject> ships;
    public GameObject tutorialMap;

    public TextMeshProUGUI direction0;
    public TextMeshProUGUI direction1;

    public GameObject lastDirectionButton;

    bool started;

    public int shipId;
    public KeyCode shipRotate;
    public KeyCode shipShoot;

    // Start is called before the first frame update
    void Start()
    {
        shipRotate = KeyCode.A;
        shipShoot = KeyCode.S;

        prepScreen.SetActive(false);
        directionScreen.SetActive(false);
        lastDirectionButton.SetActive(false);
        endScreen.SetActive(false);

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
        if (started && ships[0] == null)
        {
            endScreen.SetActive(true);
            tutorialMap.SetActive(false);
            ships[0] = Instantiate(playerShip, new Vector3(0, 10, 0),
    playerShip.transform.rotation);
            ships[0].GetComponent<MutualShip>().id = shipId;
            ships[0].GetComponent<PlayerController>().turn = shipRotate;
            ships[0].GetComponent<PlayerController>().shoot = shipShoot;
            ships[0].SetActive(false);
        }
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
        started = true;
    }

    public void nextDirection()
    {
        if (direction0.gameObject.activeSelf)
        {
            direction0.gameObject.SetActive(false);
            direction1.gameObject.SetActive(true);
            lastDirectionButton.SetActive(true);
        }
    }

    public void lastDirection()
    {
        if (direction1.gameObject.activeSelf)
        {
            direction1.gameObject.SetActive(false);
            direction0.gameObject.SetActive(true);
            lastDirectionButton.SetActive(false);
        }
    }

    public void end()
    {
        directionScreen.SetActive(false);
        endScreen.SetActive(false);
        startScreen.SetActive(true);

        direction0.gameObject.SetActive(true);
        lastDirectionButton.SetActive(false);
        direction1.gameObject.SetActive(false);
    }
}
