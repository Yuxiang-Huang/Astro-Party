using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightModeManager : MonoBehaviour
{
    GameManager gameManagerScript;

    List<int> time;
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

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        startPosY = P1Time.gameObject.transform.position.y;
        len = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //if started
        //solo / team
        //time --;
        //order the time

        //check for ending
    }

    public void startRound()
    {
        time = new List<int>() {totalTime, totalTime, totalTime, totalTime, totalTime};
        P1Time.text = "P1: " + totalTime;
        P2Time.text = "P2: " + totalTime;
        P3Time.text = "P3: " + totalTime;
        P4Time.text = "P4: " + totalTime;
        P5Time.text = "P5: " + totalTime;


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

    }
}
