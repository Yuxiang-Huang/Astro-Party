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

        Debug.Log(P1.transform.position.x + relativeOffSet);
        Debug.Log(startPosX + P1Score * lengthOfSquare);

        if (! closeEnough(P1.transform.position.x + relativeOffSet, startPosX + P1Score * lengthOfSquare))
        {

            yield return new WaitForSeconds(1f);
            P1.transform.position = new Vector3(P1.transform.position.x + lengthOfSquare, P1.transform.position.y,
                P1.transform.position.z);

            Debug.Log(P1.transform.position.x);
        }

        Debug.Log(P2.transform.position.x + relativeOffSet);
        Debug.Log(startPosX + P2Score * lengthOfSquare);

        if (! closeEnough(P2.transform.position.x + relativeOffSet, startPosX + P2Score * lengthOfSquare))
        {

            yield return new WaitForSeconds(1f);
            P2.transform.position = new Vector3(P2.transform.position.x + lengthOfSquare, P2.transform.position.y,
                P2.transform.position.z);

            Debug.Log(P2.transform.position.x);
        }

        scoreScreen.SetActive(false);
        gameManagerScript.spawnShips();
    }

    bool closeEnough(float one, float two)
    {
        return Mathf.Abs(Mathf.Abs(two - one) / two) < 0.01;
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
