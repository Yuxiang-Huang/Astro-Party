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
    int finishLineX = 200;

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

        while (P1.transform.position.y != finishLineX - P1Score * lengthOfSquare)
        {
            yield return new WaitForSeconds(1f);
            P1.transform.position = new Vector3(P1.transform.position.x, P1.transform.position.y, P1.transform.position.z
                + lengthOfSquare);
        }

        while (P2.transform.position.y != finishLineX - P2Score * lengthOfSquare)
        {
            yield return new WaitForSeconds(1f);
            P2.transform.position = new Vector3(P2.transform.position.x, P2.transform.position.y, P2.transform.position.z
                + lengthOfSquare);
        }

        while (P3.transform.position.y != finishLineX - P3Score * lengthOfSquare)
        {
            yield return new WaitForSeconds(1f);
            P3.transform.position = new Vector3(P3.transform.position.x, P3.transform.position.y, P3.transform.position.z
                + lengthOfSquare);
        }

        while (P4.transform.position.y != finishLineX - P4Score * lengthOfSquare)
        {
            yield return new WaitForSeconds(1f);
            P4.transform.position = new Vector3(P4.transform.position.x, P4.transform.position.y, P4.transform.position.z
                + lengthOfSquare);
        }


        scoreScreen.SetActive(false);
        gameManagerScript.spawnShips();
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
