using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject shipScreen;
    public GameObject lastScreen;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
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
