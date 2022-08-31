using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    GameManager gameManagerScript;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;

    public GameObject endScreen;
    public GameObject scoreScreen;

    int lengthOfSquare;
    int startPosX = -300;
    int relativeOffSet = -300 - 193;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        lengthOfSquare = 500 / 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator scoreUpdate()
    {

        scoreScreen.SetActive(true);

        yield return new WaitForSeconds(1f);

        while (closeEnough(P1.transform.position.x + relativeOffSet, startPosX + P1Score * lengthOfSquare))
        {
            Debug.Log(P1.transform.position.x + relativeOffSet);

            yield return new WaitForSeconds(2f);
            P1.transform.position = new Vector3(P1.transform.position.x + lengthOfSquare / 4, P1.transform.position.y,
                P1.transform.position.z);
        }

        while (closeEnough(P2.transform.position.x + relativeOffSet, startPosX + P2Score * lengthOfSquare))
        {

            Debug.Log(P2.transform.position.x + relativeOffSet);

            yield return new WaitForSeconds(2f);
            P2.transform.position = new Vector3(P2.transform.position.x + lengthOfSquare / 4, P2.transform.position.y,
                P2.transform.position.z);
        }

        while (P3.transform.position.x + relativeOffSet != startPosX + P3Score * lengthOfSquare)
        {
            yield return new WaitForSeconds(1f);
            P3.transform.position = new Vector3(P3.transform.position.x + lengthOfSquare / 4, P3.transform.position.y,
                P3.transform.position.z);
        }

        while (P4.transform.position.x + relativeOffSet != startPosX + P4Score * lengthOfSquare)
        {
            yield return new WaitForSeconds(1f);
            P4.transform.position = new Vector3(P4.transform.position.x + lengthOfSquare / 4, P4.transform.position.y,
                P4.transform.position.z);
        }

        scoreScreen.SetActive(false);
        gameManagerScript.spawnShips();
    }

    bool closeEnough(float one, float two)
    {
        return (two - one) / two < 0.01;
    }

    public void rematch()
    {
        endScreen.SetActive(false);
    }

    public void endBack()
    {
        endScreen.SetActive(false);
    }
}
