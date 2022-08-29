using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    GameManager gameManagerScript;

    public GameObject P1Team1Text;
    public GameObject P1Team2Text;
    public GameObject P1Team3Text;
    public GameObject P1Team4Text;
    public Text P1RotateText;
    public Text P1ShootText;

    public GameObject P2Team1Text;
    public GameObject P2Team2Text;
    public GameObject P2Team3Text;
    public GameObject P2Team4Text;
    public Text P2RotateText;
    public Text P2ShootText;

    public GameObject P3Team1Text;
    public GameObject P3Team2Text;
    public GameObject P3Team3Text;
    public GameObject P3Team4Text;
    public Text P3RotateText;
    public Text P3ShootText;

    public GameObject P4Team1Text;
    public GameObject P4Team2Text;
    public GameObject P4Team3Text;
    public GameObject P4Team4Text;
    public Text P4RotateText;
    public Text P4ShootText;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void P1SwitchTeamText()
    {
        switchTeamTextHelper(P1Team1Text, P1Team2Text, P1Team3Text, P1Team4Text);
    }

    public void P2SwitchTeamText()
    {
        switchTeamTextHelper(P2Team1Text, P2Team2Text, P2Team3Text, P2Team4Text);
    }

    public void P3SwitchTeamText()
    {
        switchTeamTextHelper(P3Team1Text, P3Team2Text, P3Team3Text, P3Team4Text);
    }

    public void P4SwitchTeamText()
    {
        switchTeamTextHelper(P4Team1Text, P4Team2Text, P4Team3Text, P4Team4Text);
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

    public void P1SetRotate()
    {
        PlayerController script = gameManagerScript.P1ShipPlayer.GetComponent<PlayerController>();
        setRotateHelper(script, P1RotateText);
    }

    public void P1SetShoot()
    {
        PlayerController script = gameManagerScript.P1ShipPlayer.GetComponent<PlayerController>();
        setShootHelper(script, P1ShootText);
    }

    public void P2SetRotate()
    {
        PlayerController script = gameManagerScript.P2ShipPlayer.GetComponent<PlayerController>();
        setRotateHelper(script, P2RotateText);
    }

    public void P2SetShoot()
    {
        PlayerController script = gameManagerScript.P2ShipPlayer.GetComponent<PlayerController>();
        setShootHelper(script, P2ShootText);
    }

    public void P3SetRotate()
    {
        PlayerController script = gameManagerScript.P3ShipPlayer.GetComponent<PlayerController>();
        setRotateHelper(script, P3RotateText);
    }

    public void P3SetShoot()
    {
        PlayerController script = gameManagerScript.P3ShipPlayer.GetComponent<PlayerController>();
        setShootHelper(script, P3ShootText);
    }

    public void P4SetRotate()
    {
        PlayerController script = gameManagerScript.P4ShipPlayer.GetComponent<PlayerController>();
        setRotateHelper(script, P4RotateText);
    }

    public void P4SetShoot()
    {
        PlayerController script = gameManagerScript.P4ShipPlayer.GetComponent<PlayerController>();
        setShootHelper(script, P4ShootText);
    }

    void setRotateHelper(PlayerController script, Text changeText)
    {
        KeyCode now = KeyCode.None;

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                now = kcode;
        }

        script.turn = now;
        changeText.text = now.ToString();
    }

    void setShootHelper(PlayerController script, Text changeText)
    {
        KeyCode now = KeyCode.None;

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                now = kcode;
        }

        script.shoot = now;
        changeText.text = now.ToString();
    }
}
