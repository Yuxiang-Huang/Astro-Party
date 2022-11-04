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
    public TextMeshProUGUI[] PTime;
    List<KeyValuePair<TextMeshProUGUI, float>> data;

    public int totalTime = 60;

    public GameObject crown;
    public GameObject crownPic;
    int crownY = 10;
    float startTimeY;
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
        startTimeY = PTime[0].gameObject.transform.position.y;
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
                PTime[ID - 1].text = "P" + ID + ": " + (int)times[ID-1];

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

        //time text
        times = new float[5];
        for (int i = 0; i < 5; i++)
        {
            times[i] = totalTime;
        }

        data = new List<KeyValuePair<TextMeshProUGUI, float>>();

        for (int i = 0; i < PTime.Length; i++)
        {
            PTime[i].text = "P" + (i + 1) + ": " + (int)times[i];
            PTime[i].gameObject.SetActive(false);

            //for ordering
            data.Add(new KeyValuePair<TextMeshProUGUI, float>(PTime[i], times[i])); 
        }

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                PTime[ship.GetComponent<MutualShip>().id - 1].gameObject.SetActive(true);
            }
        }

       Instantiate(crown, spawnManagerScript.generateRanPos(crownY), crown.transform.rotation);
    }

    public void assign(int ID, Vector3 pos, bool suicided)
    {
        if (suicided)
        {
            Instantiate(crown, new Vector3(pos.x, crownY, pos.z), crown.transform.rotation);
        }
        else
        {
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
        }
    }

    void end(int winner)
    {
        started = false;

        //reset the board
        for (int i = 0; i < PTime.Length; i++)
        {
            Vector3 pos = PTime[i].transform.position;
            PTime[i].transform.position = new Vector3(pos.x, startTimeY + i * len, pos.z);
        }

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
