using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is text for ship screen
public class TextManager : MonoBehaviour
{
    GameManager gameManagerScript;

    public Text P1TeamText;
    public Text P1RotateText;
    public Text P1ShootText;

    public Text P2TeamText;
    public Text P2RotateText;
    public Text P2ShootText;

    public Text P3TeamText;
    public Text P3RotateText;
    public Text P3ShootText;

    public Text P4TeamText;
    public Text P4RotateText;
    public Text P4ShootText;

    public Text P5TeamText;
    public Text P5RotateText;
    public Text P5ShootText;

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
        P1TeamText.text = (gameManagerScript.P1Team + 1).ToString();
    }

    public void P2SwitchTeamText()
    {
        P2TeamText.text = (gameManagerScript.P2Team + 1).ToString();
    }

    public void P3SwitchTeamText()
    {
        P3TeamText.text = (gameManagerScript.P3Team + 1).ToString();
    }

    public void P4SwitchTeamText()
    {
        P4TeamText.text = (gameManagerScript.P4Team + 1).ToString();
    }

    public void P5SwitchTeamText()
    {
        P5TeamText.text = (gameManagerScript.P5Team + 1).ToString();
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

    public void P5SetRotate()
    {
        PlayerController script = gameManagerScript.P5ShipPlayer.GetComponent<PlayerController>();
        setRotateHelper(script, P5RotateText);
    }

    public void P5SetShoot()
    {
        PlayerController script = gameManagerScript.P5ShipPlayer.GetComponent<PlayerController>();
        setShootHelper(script, P5ShootText);
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
