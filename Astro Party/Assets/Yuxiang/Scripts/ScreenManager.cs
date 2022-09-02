using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    ScoreManager scoreManagerScript;
    GameManager gameManagerScript;

    public GameObject startScreen;
    public GameObject shipScreen;
    public GameObject lastScreen;
    public GameObject infoScreen;

    public GameObject friendlyFireButton;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        shipScreen.SetActive(false);
        lastScreen.SetActive(false);
        infoScreen.SetActive(false);

        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextToShip()
    {
        startScreen.SetActive(false);
        shipScreen.SetActive(true);
    }

    public void nextToLast()
    {
        shipScreen.SetActive(false);
        lastScreen.SetActive(true);

        //determine game mode to be solo or team

        scoreManagerScript.gameMode = "solo";

        for (int i = 0; i < gameManagerScript.ships.Count; i++)
        {
            if (gameManagerScript.ships[i].Count > 1)
            {
                scoreManagerScript.gameMode = "team";
            }
        }

        if (scoreManagerScript.gameMode == "team")
        {
            friendlyFireButton.SetActive(true);
        }
        else
        {
            friendlyFireButton.SetActive(false);
        }
    }

    public void nextToInfo()
    {
        startScreen.SetActive(false);
        infoScreen.SetActive(true);
    }

    public void backToStart()
    {
        shipScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void backToShip()
    {
        lastScreen.SetActive(false);
        shipScreen.SetActive(true);
    }

    public void play()
    {
        lastScreen.SetActive(false);
    }
}
