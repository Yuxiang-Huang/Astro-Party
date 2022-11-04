using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightModeManager : MonoBehaviour
{
    GameManager gameManagerScript;

    float[] times;
    public TextMeshProUGUI P1Time;
    public TextMeshProUGUI P2Time;
    public TextMeshProUGUI P3Time;
    public TextMeshProUGUI P4Time;
    public TextMeshProUGUI P5Time;

    public GameObject P1WinText;
    public GameObject P2WinText;
    public GameObject P3WinText;
    public GameObject P4WinText;
    public GameObject P5WinText;

    public GameObject Team1WinText;
    public GameObject Team2WinText;
    public GameObject Team3WinText;
    public GameObject Team4WinText;
    public GameObject Team5WinText;

    public GameObject endScreen;

    public int totalTime = 60;

    float startPosY;
    float len;

    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        startPosY = P1Time.gameObject.transform.position.y;
        len = 30;

        times = new float[5];
    }

    // Update is called once per frame
    void Update()
    {
        int ID = -1;

        if (started)
        {
            //solo / team

            //find highlighted ship
            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                foreach (GameObject ship in shipList)
                {
                    if (ship.GetComponent<MutualShip>().highlighed)
                    {
                        ID = ship.GetComponent<MutualShip>().id;
                    }
                }
            }

            times[ID] -= Time.deltaTime;

            if (times[ID] <= 0)
            {
                end();
            }

            switch (ID)
            {
                case 1:
                    P1Time.text = "P1: " + times[0];
                    break;
                case 2:
                    P2Time.text = "P2: " + times[1];
                    break;
                case 3:
                    P3Time.text = "P3: " + times[2];
                    break;
                case 4:
                    P4Time.text = "P4: " + times[3];
                    break;
                case 5:
                    P5Time.text = "P5: " + times[4];
                    break;
            }

            //order the time
        }
    }

    public void startRound()
    {
        started = true;

        times = new float[5];
        for (int i = 0; i < 5; i++)
        {
            times[i] = totalTime;
        }

        P1Time.text = "P1: " + times[0];
        P2Time.text = "P2: " + times[1];
        P3Time.text = "P3: " + times[2];
        P4Time.text = "P4: " + times[3];
        P5Time.text = "P5: " + times[4];


        //for now just higlight first ship
        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                ship.GetComponent<MutualShip>().highlighed = true;
                break;
            }
        }
    }

    public void assign(int ID)
    {
        bool assigned = false;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                if (ship.GetComponent<MutualShip>().id == ID)
                {
                    ship.GetComponent<MutualShip>().highlighed = true;
                    assigned = true;
                }
            }
        }

        if (!assigned)
        {
            //for now just higlight first ship
            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                foreach (GameObject ship in shipList)
                {
                    ship.GetComponent<MutualShip>().highlighed = true;
                    break;
                }
            }
        }
    }

    void end()
    {
        started = false;
        
    }
}
