using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject prepScreen;

    public GameObject playerShip;

    public List<GameObject> ships;

    // Start is called before the first frame update
    void Start()
    {
        prepScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prep()
    {
        startScreen.SetActive(false);
        prepScreen.SetActive(true);
    }

    public void backToStart()
    {
        prepScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void startTutorial()
    {
        prepScreen.SetActive(false);
    }
}
