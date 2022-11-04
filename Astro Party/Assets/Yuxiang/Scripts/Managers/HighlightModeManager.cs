using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightModeManager : MonoBehaviour
{
    GameManager gameManagerScript;
    ScoreManager scoreManagerScript;
    SpawnManager spawnManagerScript;

    float[] times;
    public TextMeshProUGUI P1Time;
    public TextMeshProUGUI P2Time;
    public TextMeshProUGUI P3Time;
    public TextMeshProUGUI P4Time;
    public TextMeshProUGUI P5Time;

    public int totalTime = 60;

    public GameObject crown;
    public GameObject crownPic;
    int crownY = 10;
    float startPosY;
    public float len;
    public Canvas canvas;

    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        //set variables
        canvas.gameObject.SetActive(true);
        startPosY = crownPic.transform.position.y;
        float scale = canvas.scaleFactor;
        len *= scale;
        canvas.gameObject.SetActive(false);

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
                    if (ship.GetComponent<MutualShip>() != null)
                    {
                        if (ship.GetComponent<MutualShip>().highlighed)
                        {
                            ID = ship.GetComponent<MutualShip>().id;
                        }
                    }
                }
            }

            if (ID == -1)
            {
                crownPic.SetActive(false);
            }
            else
            {
                crownPic.SetActive(true);

                times[ID - 1] -= Time.deltaTime;

                //change time
                switch (ID)
                {
                    case 1:
                        P1Time.text = "P1: " + (int)times[0];
                        break;
                    case 2:
                        P2Time.text = "P2: " + (int)times[1];
                        break;
                    case 3:
                        P3Time.text = "P3: " + (int)times[2];
                        break;
                    case 4:
                        P4Time.text = "P4: " + (int)times[3];
                        break;
                    case 5:
                        P5Time.text = "P5: " + (int)times[4];
                        break;
                }

                //check for ending
                if (times[ID - 1] <= 0)
                {
                    end(ID);
                }

                //update position
                Vector3 pos = crownPic.transform.position;
                crownPic.transform.position = new Vector3(pos.x, startPosY + (ID - 1) * len, pos.z);

                //order the time
            }
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

        Instantiate(crown, spawnManagerScript.generateRanPos(crownY), crown.transform.rotation);
    }

    public void assign(int ID, Vector3 pos)
    {
        //didn't work...
        //bool assigned = false;

        //assign to the ship that killed it
        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                if (ship.GetComponent<MutualShip>() != null)
                {
                    if (ship.GetComponent<MutualShip>().id == ID)
                    {
                        ship.GetComponent<MutualShip>().highlighed = true;
                        //assigned = true;
                    }
                }
            }
        }

        //bad way to spawn a crown in suicidal scenario
        int curr = -1;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                if (ship.GetComponent<MutualShip>() != null)
                {
                    if (ship.GetComponent<MutualShip>().highlighed)
                    {
                        curr = ship.GetComponent<MutualShip>().id;
                    }
                }
            }
        }

        if (curr == -1)
        {
            Instantiate(crown, new Vector3(pos.x, crownY, pos.z), crown.transform.rotation);
        }
    }

    void end(int winner)
    {
        started = false;
        //solo vs team
        switch (winner)
        {
            case 1:
                scoreManagerScript.P1WinText.SetActive(true);
                break;
            case 2:
                scoreManagerScript.P2WinText.SetActive(true);
                break;
            case 3:
                scoreManagerScript.P3WinText.SetActive(true);
                break;
            case 4:
                scoreManagerScript.P4WinText.SetActive(true);
                break;
            case 5:
                scoreManagerScript.P5WinText.SetActive(true);
                break;
        }
        scoreManagerScript.endScreen.SetActive(true);
        scoreManagerScript.pauseText.SetActive(false);
    }
}
