using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public string gameMode;

    GameManager gameManagerScript;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;

    public GameObject P1WinText;
    public GameObject P2WinText;
    public GameObject P3WinText;
    public GameObject P4WinText;

    public GameObject Team1WinText;
    public GameObject Team2WinText;
    public GameObject Team3WinText;
    public GameObject Team4WinText;

    int scoreToWin = 5;
    public Text roundText;

    public GameObject endScreen;
    public GameObject scoreScreen;

    int lengthOfSquare;
    int startPosX = -300;
    int relativeOffSet = -300 - 193;

    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        scoreScreen.SetActive(false);

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator scoreUpdate()
    {

        scoreScreen.SetActive(true);

        while (! closeEnough(P1.transform.position.x + relativeOffSet, startPosX + P1Score * lengthOfSquare))
        {

            yield return new WaitForSeconds(1f);
            P1.transform.position = new Vector3(P1.transform.position.x + lengthOfSquare, P1.transform.position.y,
                P1.transform.position.z);

            //Debug.Log(P1.transform.position.x + relativeOffSet);
            //Debug.Log(startPosX + P1Score * lengthOfSquare);
        }

        while (! closeEnough(P2.transform.position.x + relativeOffSet, startPosX + P2Score * lengthOfSquare))
        {

            yield return new WaitForSeconds(1f);
            P2.transform.position = new Vector3(P2.transform.position.x + lengthOfSquare, P2.transform.position.y,
                P2.transform.position.z);

            //Debug.Log(P2.transform.position.x + relativeOffSet);
            //Debug.Log(startPosX + P2Score * lengthOfSquare);
        }

        while (!closeEnough(P3.transform.position.x + relativeOffSet, startPosX + P3Score * lengthOfSquare))
        {

            yield return new WaitForSeconds(1f);
            P3.transform.position = new Vector3(P3.transform.position.x + lengthOfSquare, P3.transform.position.y,
                P3.transform.position.z);
        }

        while (!closeEnough(P4.transform.position.x + relativeOffSet, startPosX + P4Score * lengthOfSquare))
        {

            yield return new WaitForSeconds(1f);
            P4.transform.position = new Vector3(P4.transform.position.x + lengthOfSquare, P4.transform.position.y,
                P4.transform.position.z);
        }

        yield return new WaitForSeconds(2f);

        scoreScreen.SetActive(false);

        if (P1Score < scoreToWin && P2Score < scoreToWin && P3Score < scoreToWin && P4Score < scoreToWin)
        {
            gameManagerScript.spawnShips();
        }
        else
        {
            endScreen.SetActive(true);
            if (gameMode == "team")
            {
                Team1WinText.SetActive(false);
                Team2WinText.SetActive(false);
                Team3WinText.SetActive(false);
                Team4WinText.SetActive(false);

                int find = -1;

                if (P1Score == scoreToWin)
                {
                    find = 1;
                }
                if (P2Score == scoreToWin)
                {
                    find = 2;
                }
                if (P3Score == scoreToWin)
                {
                    find = 3;
                }
                if (P4Score == scoreToWin)
                {
                    find = 4;
                }

                switch (findWinningTeam(find))
                {
                    case 1:
                        Team1WinText.SetActive(true);
                        break;
                    case 2:
                        Team2WinText.SetActive(true);
                        break;
                    case 3:
                        Team3WinText.SetActive(true);
                        break;
                    case 4:
                        Team4WinText.SetActive(true);
                        break;
                }
            }
            if (gameMode == "solo")
            {
                P1WinText.SetActive(false);
                P2WinText.SetActive(false);
                P3WinText.SetActive(false);
                P4WinText.SetActive(false);

                int find = -1;

                if (P1Score == scoreToWin)
                {
                    find = 1;
                }
                if (P2Score == scoreToWin)
                {
                    find = 2;
                }
                if (P3Score == scoreToWin)
                {
                    find = 3;
                }
                if (P4Score == scoreToWin)
                {
                    find = 4;
                }
                switch (find)
                {
                    case 1:
                        P1WinText.SetActive(true);
                        break;
                    case 2:
                        P2WinText.SetActive(true);
                        break;
                    case 3:
                        P3WinText.SetActive(true);
                        break;
                    case 4:
                        P4WinText.SetActive(true);
                        break;
                }
            }
    }

    int findWinningTeam(int shipID)
    {
        for (int i = 0; i < gameManagerScript.ships.Count; i++)
        {
            for (int j = 0; j < gameManagerScript.ships[i].Count; j++)
            {
                if (gameManagerScript.ships[i][j].GetComponent<ID>().id == shipID)
                {
                    return i + 1;
                }
            }
        }
        return -1;
    }

    bool closeEnough(float one, float two)
    {
        return Mathf.Abs(one - two) < 1;
    }

    public void rematch()
    {
        endScreen.SetActive(false);
    }

    public void endBack()
    {
        endScreen.SetActive(false);
    }

    public void changeRound()
    {
        if (scoreToWin == 3)
        {
            scoreToWin = 5;
            roundText.text = "Standard \n5 WINS";
        }

        else if (scoreToWin == 5)
        {
            scoreToWin = 7;
            roundText.text = "Long \n7 WINS";
        }

        else if(scoreToWin == 7)
        {
            scoreToWin = 3;
            roundText.text = "Quick \n3 WINS";
        }

        lengthOfSquare = 500 / scoreToWin * 2;
    }
}
