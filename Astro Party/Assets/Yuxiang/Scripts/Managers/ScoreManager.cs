using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public string gameMode;
    public string shipMode;

    GameManager gameManagerScript;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;

    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;
    public int P5Score;

    public bool P1Suicide;
    public bool P2Suicide;
    public bool P3Suicide;
    public bool P4Suicide;
    public bool P5Suicide;

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

    public GameObject scoreBoard;

    int scoreToWin = 5;
    public Text roundText;
    int maxScore = 5;
    List<int> winningShip;

    public bool friendlyFire = false;
    public Text friendlyFireText;

    public GameObject endScreen;
    public GameObject scoreScreen;

    float lengthOfSquare;
    float origStartPosX;
    float startPosX;
    float startPosXScoreBoard;

    public Text teamModeText;
    public Text soloModeText;

    public GameObject pauseText;

    public Canvas canvas;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        scoreScreen.SetActive(true);

        origStartPosX = P1.transform.position.x;
        startPosX = P1.transform.position.x;
        startPosXScoreBoard= scoreBoard.transform.position.x;

        scale = canvas.scaleFactor;
        lengthOfSquare = 500 / scoreToWin * scale;

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        resetScore();
        endScreen.SetActive(false);
        scoreScreen.SetActive(false);

        shipMode = "ship";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameStarted)
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
    }

    public IEnumerator scoreUpdate()
    {
        //Debug.Log(startPosX);
        //Debug.Log(P1.transform.position.x);
        //Debug.Log(P1.transform.position.x - startPosX);
        //Debug.Log(P1Score * lengthOfSquare);

        scoreScreen.SetActive(true);

        if (gameMode == "solo")
        {
            while (!closeEnough(P1.transform.position.x - startPosX, P1Score * lengthOfSquare))
            {
                yield return new WaitForSeconds(1f);
                checkPSolo(P1, P1Score, 1);
            }

            if (P1Suicide)
            {
                yield return new WaitForSeconds(1f);
                if (P1Score > 0)
                {
                    move(P1, -lengthOfSquare);
                    P1Score--;
                }

                for (int i = 0; i < 8; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    P1.transform.Rotate(new Vector3(0, 0, 45));
                }

                P1Suicide = false;
            }

            while (!closeEnough(P2.transform.position.x - startPosX, P2Score * lengthOfSquare))
            {
                yield return new WaitForSeconds(1f);
                checkPSolo(P2, P2Score, 2);
            }

            if (P2Suicide)
            {
                yield return new WaitForSeconds(1f);
                if (P2Score > 0)
                {
                    P2.transform.position = new Vector3(P2.transform.position.x - lengthOfSquare, P2.transform.position.y,
    P2.transform.position.z);
                    P2Score--;
                }

                for (int i = 0; i < 8; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    P2.transform.Rotate(new Vector3(0, 0, 45));
                }

                P2Suicide = false;
            }

            while (!closeEnough(P3.transform.position.x - startPosX, P3Score * lengthOfSquare))
            {
                yield return new WaitForSeconds(1f);
                checkPSolo(P3, P3Score, 3);
            }

            if (P3Suicide)
            {
                yield return new WaitForSeconds(1f);
                if (P3Score > 0)
                {
                    P3.transform.position = new Vector3(P3.transform.position.x - lengthOfSquare, P3.transform.position.y,
    P3.transform.position.z);
                    P3Score--;
                }

                for (int i = 0; i < 8; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    P3.transform.Rotate(new Vector3(0, 0, 45));
                }

                P3Suicide = false;
            }

            while (!closeEnough(P4.transform.position.x - startPosX, P4Score * lengthOfSquare))
            {
                yield return new WaitForSeconds(1f);
                checkPSolo(P4, P4Score, 4);
            }

            if (P4Suicide)
            {
                yield return new WaitForSeconds(1f);
                if (P4Score > 0)
                {
                    P4.transform.position = new Vector3(P4.transform.position.x - lengthOfSquare, P4.transform.position.y,
    P4.transform.position.z);
                    P4Score--;
                }

                for (int i = 0; i < 8; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    P4.transform.Rotate(new Vector3(0, 0, 45));
                }

                P4Suicide = false;
            }

            while (!closeEnough(P5.transform.position.x - startPosX, P5Score * lengthOfSquare))
            {
                yield return new WaitForSeconds(1f);
                checkPSolo(P5, P5Score, 5);
            }


            if (P5Suicide)
            {
                yield return new WaitForSeconds(1f);
                if (P5Score > 0)
                {
                    P5.transform.position = new Vector3(P5.transform.position.x - lengthOfSquare, P5.transform.position.y,
    P5.transform.position.z);
                    P5Score--;
                }

                for (int i = 0; i < 8; i++)
                {
                    yield return new WaitForSeconds(0.05f);
                    P5.transform.Rotate(new Vector3(0, 0, 45));
                }

                P5Suicide = false;
            }
        }

        else if (gameMode == "team")
        {
            yield return new WaitForSeconds(1f);
            checkPScoreTeam(P1, P1Score, 1);
            checkPScoreTeam(P2, P2Score, 2);
            checkPScoreTeam(P3, P3Score, 3);
            checkPScoreTeam(P4, P4Score, 4);
            checkPScoreTeam(P5, P5Score, 5);
        }

        yield return new WaitForSeconds(2f);

        scoreScreen.SetActive(false);

        //Check for winner
        if (winningShip.Count == 0)
        {
            gameManagerScript.startRound();
        }
        else
        {
            endScreen.SetActive(true);
            pauseText.SetActive(false);
            if (gameMode == "team")
            {
                Team1WinText.SetActive(false);
                Team2WinText.SetActive(false);
                Team3WinText.SetActive(false);
                Team4WinText.SetActive(false);
                Team5WinText.SetActive(false);

                switch (findWinningTeam(winningShip[0]))
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
                    case 5:
                        Team5WinText.SetActive(true);
                        break;
                }
            }
            if (gameMode == "solo")
            {
                P1WinText.SetActive(false);
                P2WinText.SetActive(false);
                P3WinText.SetActive(false);
                P4WinText.SetActive(false);
                P5WinText.SetActive(false);

                int find = -1;

                if (P1Score >= scoreToWin)
                {
                    find = 1;
                }
                if (P2Score >= scoreToWin)
                {
                    find = 2;
                }
                if (P3Score >= scoreToWin)
                {
                    find = 3;
                }
                if (P4Score >= scoreToWin)
                {
                    find = 4;
                }
                if (P5Score >= scoreToWin)
                {
                    find = 5;
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
                    case 5:
                        P5WinText.SetActive(true);
                        break;
                }
            }
        }
    }

    void checkPScoreTeam(GameObject P, int PScore, int id)
    {
        //moving the shipPic
        if (!closeEnough(P.transform.position.x - startPosX, PScore * lengthOfSquare))
        {
            P.transform.position = new Vector3(P.transform.position.x + lengthOfSquare, P.transform.position.y,
                P.transform.position.z);
        }

        //checking for winner
        if (PScore == maxScore)
        {
            winningShip.Add(id);
        }
    }

    void checkPSolo(GameObject P, int PScore, int id)
    {
        move(P, lengthOfSquare);
        
        if (closeEnough(P.transform.position.x - startPosX, lengthOfSquare * (maxScore + 1)))
        {
            moveEverything();
            startPosX -= lengthOfSquare;
            maxScore++;
            winningShip = new List<int>();
            winningShip.Add(id);
        } else if (PScore == maxScore)
        {
            winningShip.Add(id);
        }
    }

    void move(GameObject P, float len)
    {
        P.transform.position = new Vector3(P.transform.position.x + len, P.transform.position.y,
                    P.transform.position.z);
    }

    //for exceeding the point require to win
    void moveEverything()
    {
        move(P1, -lengthOfSquare);
        move(P2, -lengthOfSquare);
        move(P3, -lengthOfSquare);
        move(P4, -lengthOfSquare);
        move(P5, -lengthOfSquare);
        move(scoreBoard, -lengthOfSquare);
    }

    int findWinningTeam(int shipID)
    {
        //the index of the list containing the winning ship id
        for (int i = 0; i < gameManagerScript.ships.Count; i++)
        {
            for (int j = 0; j < gameManagerScript.ships[i].Count; j++)
            {
                if (gameManagerScript.ships[i][j].GetComponent<MutualShip>().id == shipID)
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

    //Buttons

    public void resetScore()
    {
        winningShip = new List<int>();

        startPosX = origStartPosX;
        maxScore = scoreToWin;

        P1Score = 0;
        P2Score = 0;
        P3Score = 0;
        P4Score = 0;
        P5Score = 0;

        P1WinText.SetActive(false);
        P2WinText.SetActive(false);
        P3WinText.SetActive(false);
        P4WinText.SetActive(false);
        P5WinText.SetActive(false);

        Team1WinText.SetActive(false);
        Team2WinText.SetActive(false);
        Team3WinText.SetActive(false);
        Team4WinText.SetActive(false);
        Team5WinText.SetActive(false);

    //Debug.Log(P1.transform.position);
    //Debug.Log(P2.transform.position);
    //Debug.Log(P3.transform.position);
    //Debug.Log(P4.transform.position);

        scoreScreen.SetActive(true);

        P1.transform.position = new Vector3(startPosX, P1.transform.position.y,
                P1.transform.position.z);
        P2.transform.position = new Vector3(startPosX, P2.transform.position.y,
                P2.transform.position.z);
        P3.transform.position = new Vector3(startPosX, P3.transform.position.y,
                P3.transform.position.z);
        P4.transform.position = new Vector3(startPosX, P4.transform.position.y,
                P4.transform.position.z);
        P5.transform.position = new Vector3(startPosX, P5.transform.position.y,
                P5.transform.position.z);
        scoreBoard.transform.position = new Vector3(startPosXScoreBoard, scoreBoard.transform.position.y,
                scoreBoard.transform.position.z);

        //for pause
        gameManagerScript.gameStarted = false;

        Time.timeScale = 1;

        scoreScreen.SetActive(false);

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

        lengthOfSquare = 500 / scoreToWin * scale;
        maxScore = scoreToWin;
    }

    public void setFriendlyFire()
    {
        if (friendlyFire)
        {
            friendlyFireText.text = "Friendly Fire: Off";
        }
        else
        {
            friendlyFireText.text = "Friendly Fire: On";
        }

        friendlyFire = !friendlyFire;
    }

    public void setShipMode()
    {
        if (shipMode == "ship")
        {
            shipMode = "pilot";
            teamModeText.text = "Team Pilot Hunter";
            soloModeText.text = "Solo Pilot Hunter";
        }
        else if (shipMode == "pilot")
        {
            shipMode = "ship";
            teamModeText.text = "Team Ship Hunter";
            soloModeText.text = "Solo Ship Hunter";
        }
    }
}
