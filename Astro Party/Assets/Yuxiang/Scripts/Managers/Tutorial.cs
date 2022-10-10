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

    public GameObject endScreenText;

    public GameObject playerShip;

    public List<GameObject> ships;
    public GameObject tutorialMap;

    public List<GameObject> directions;
    int directionId = 0;

    public GameObject lastDirectionButton;
    public GameObject nextDirectionButton;

    bool started;

    public int shipId;
    public KeyCode shipRotate;
    public KeyCode shipShoot;

    // Start is called before the first frame update
    void Start()
    {
        shipRotate = KeyCode.A;
        shipShoot = KeyCode.S;

        GameObject shipPlayer = Instantiate(playerShip, new Vector3(0, 10, 0),
    playerShip.transform.rotation);
        shipPlayer.SetActive(false);

        ships.Add(shipPlayer);

        end();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (endScreen.activeSelf)
                {
                    endScreen.SetActive(false);
                    Time.timeScale = 1;
                }
                else
                {
                    endScreen.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }

        if (started && ships[0] == null)
        {
            endScreen.SetActive(true);
            endScreenText.SetActive(true);
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
        directions[0].gameObject.SetActive(true);
        started = true;
    }

    public void nextDirection()
    {
        if (directionId == 0)
        {
            lastDirectionButton.SetActive(true);
        }

        directions[directionId].SetActive(false);
        directionId++;
        directions[directionId].SetActive(true);

        if (directionId == directions.Count - 1)
        {
            nextDirectionButton.SetActive(false);
        }
    }

    public void lastDirection()
    {
        if (directionId == directions.Count - 1)
        {
            nextDirectionButton.SetActive(true);
        }

        directions[directionId].SetActive(false);
        directionId--;
        directions[directionId].SetActive(true);

        if (directionId == 0)
        {
            lastDirectionButton.SetActive(false);
        }
    }

    public void end()
    {
        //reset the ship
        Destroy(ships[0]);
        ships[0] = Instantiate(playerShip, new Vector3(0, 10, 0),
playerShip.transform.rotation);
        ships[0].GetComponent<MutualShip>().id = shipId;
        ships[0].GetComponent<PlayerController>().turn = shipRotate;
        ships[0].GetComponent<PlayerController>().shoot = shipShoot;
        ships[0].SetActive(false);

        //screens and maps
        prepScreen.SetActive(false);
        directionScreen.SetActive(false);
        endScreen.SetActive(false);
        startScreen.SetActive(true);
        tutorialMap.SetActive(false);

        //directions
        nextDirectionButton.SetActive(true);
        lastDirectionButton.SetActive(false);
        foreach (GameObject direction in directions)
        {
            direction.SetActive(false);
        }

        //others
        started = false;
        endScreenText.SetActive(false);
        Time.timeScale = 1;
    }
}
