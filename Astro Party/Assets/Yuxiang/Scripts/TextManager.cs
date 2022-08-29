using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject P1Team1Text;
    public GameObject P1Team2Text;
    public GameObject P1Team3Text;
    public GameObject P1Team4Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void P1SwitchTeamText()
    {
        switchTeamTextHelper(P1Team1Text, P1Team2Text, P1Team3Text, P1Team4Text);
    }

    void switchTeamTextHelper(GameObject Team1Text, GameObject Team2Text, GameObject Team3Text, GameObject Team4Text)
    {
        if (Team1Text.active)
        {
            Team1Text.SetActive(false);
            Team2Text.SetActive(true);
        }
        else if (Team2Text.active)
        {
            Team2Text.SetActive(false);
            Team3Text.SetActive(true);
        }
        else if (Team3Text.active)
        {
            Team3Text.SetActive(false);
            Team4Text.SetActive(true);
        }
        else if (Team4Text.active)
        {
            Team4Text.SetActive(false);
            Team1Text.SetActive(true);
        }
    }
}
