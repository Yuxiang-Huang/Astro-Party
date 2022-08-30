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

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
