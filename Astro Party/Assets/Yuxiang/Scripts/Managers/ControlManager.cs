using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    public int id;

    public GameObject shipPlayer;
    public GameObject shipBot;
    public GameObject shipBot1;
    public Text pText;
    public int team;
    public GameObject teamButtonObject;
    public GameObject setRotateButton;
    public GameObject setShootButton;
    public GameObject startingPowerUpButton;

    GameManager gameManagerScript;
    ScoreManager scoreManagerScript;

    public Text teamText;
    public Text rotateText;
    public Text shootText;

    // Start is called before the first frame update
    void Start()
    {
        team = id - 1;

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

        //Creating ships
        shipBot = Instantiate(gameManagerScript.botShip, new Vector3(0, 0, 0),
            gameManagerScript.playerShip.transform.rotation);
        shipBot.GetComponent<MutualShip>().id = id;
        shipBot.SetActive(false);

        shipBot1 = Instantiate(gameManagerScript.botShip1, new Vector3(0, 0, 0),
            gameManagerScript.playerShip.transform.rotation);
        shipBot1.GetComponent<MutualShip>().id = id;
        shipBot1.SetActive(false);

        shipPlayer = Instantiate(gameManagerScript.playerShip, new Vector3(0, 0, 0),
            gameManagerScript.playerShip.transform.rotation);
        shipPlayer.GetComponent<MutualShip>().id = id;
        shipPlayer.SetActive(false);

        gameManagerScript.allShips.Add(shipBot);
        gameManagerScript.allShips.Add(shipBot1);
        gameManagerScript.allShips.Add(shipPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shipButton()
    {
        GameObject picture = scoreManagerScript.P1;

        switch (id)
        {
            case 1: picture = scoreManagerScript.P1; break;
            case 2: picture = scoreManagerScript.P2; break;
            case 3: picture = scoreManagerScript.P3; break;
            case 4: picture = scoreManagerScript.P4; break;
            case 5: picture = scoreManagerScript.P5; break;
        }

        buttonHelper(shipPlayer, shipBot, shipBot1, teamText, team, teamButtonObject,
            setRotateButton, setShootButton, picture, startingPowerUpButton);
    }

    void buttonHelper(GameObject player, GameObject bot, GameObject bot1, Text textPlayer, int team,
        GameObject teamButton, GameObject setRotateButton, GameObject setShootButton, GameObject picture,
            GameObject startingPowerUpButton)
    {
        List<GameObject> ship = gameManagerScript.ships[team];
        if (ship.Contains(player))
        {
            textPlayer.text = "Bot1";
            ship.Remove(player);
            ship.Add(bot);

            setRotateButton.SetActive(false);
            setShootButton.SetActive(false);
        }
        else if (ship.Contains(bot))
        {
            textPlayer.text = "Bot2";
            ship.Remove(bot);
            ship.Add(bot1);
        }
        else if (ship.Contains(bot1))
        {
            textPlayer.text = "Off";
            ship.Remove(bot1);

            teamButton.SetActive(false);
            teamButton.SetActive(false);
            picture.SetActive(false);
            startingPowerUpButton.SetActive(false);
        }
        else
        {
            textPlayer.text = "P" + player.GetComponent<MutualShip>().id;
            ship.Add(player);

            setRotateButton.SetActive(true);
            setShootButton.SetActive(true);
            teamButton.SetActive(true);
            teamButton.SetActive(true);
            picture.SetActive(true);
            startingPowerUpButton.SetActive(true);
        }
    }

    public void teamButton()
    {
        GameObject curr = findShip(team, shipPlayer, shipBot);

        gameManagerScript.ships[team].Remove(curr);
        team++;

        if (team == 5)
        {
            team = 0;
        }
        gameManagerScript.ships[team].Add(curr);
    }

    GameObject findShip(int team, GameObject shipTarget, GameObject bot)
    {
        GameObject ans = null;
        List<GameObject> ship = gameManagerScript.ships[team];
        if (ship.Contains(shipTarget))
        {
            ans = shipTarget;
        }
        else if (ship.Contains(bot))
        {
            ans = bot;
        }
        return ans;
    }

//    public void P1SwitchTeamText()
//    {
//        P1TeamText.text = (gameManagerScript.P1Team + 1).ToString();
//    }

//    public void P2SwitchTeamText()
//    {
//        P2TeamText.text = (gameManagerScript.P2Team + 1).ToString();
//    }

//    public void P3SwitchTeamText()
//    {
//        P3TeamText.text = (gameManagerScript.P3Team + 1).ToString();
//    }

//    public void P4SwitchTeamText()
//    {
//        P4TeamText.text = (gameManagerScript.P4Team + 1).ToString();
//    }

//    public void P5SwitchTeamText()
//    {
//        P5TeamText.text = (gameManagerScript.P5Team + 1).ToString();
//    }

//    public void P1SetRotate()
//    {
//        PlayerController script = gameManagerScript.P1ShipPlayer.GetComponent<PlayerController>();
//        setRotateHelper(script, P1RotateText);
//    }

//    public void P1SetShoot()
//    {
//        PlayerController script = gameManagerScript.P1ShipPlayer.GetComponent<PlayerController>();
//        setShootHelper(script, P1ShootText);
//    }

//    public void P2SetRotate()
//    {
//        PlayerController script = gameManagerScript.P2ShipPlayer.GetComponent<PlayerController>();
//        setRotateHelper(script, P2RotateText);
//    }

//    public void P2SetShoot()
//    {
//        PlayerController script = gameManagerScript.P2ShipPlayer.GetComponent<PlayerController>();
//        setShootHelper(script, P2ShootText);
//    }

//    public void P3SetRotate()
//    {
//        PlayerController script = gameManagerScript.P3ShipPlayer.GetComponent<PlayerController>();
//        setRotateHelper(script, P3RotateText);
//    }

//    public void P3SetShoot()
//    {
//        PlayerController script = gameManagerScript.P3ShipPlayer.GetComponent<PlayerController>();
//        setShootHelper(script, P3ShootText);
//    }

//    public void P4SetRotate()
//    {
//        PlayerController script = gameManagerScript.P4ShipPlayer.GetComponent<PlayerController>();
//        setRotateHelper(script, P4RotateText);
//    }

//    public void P4SetShoot()
//    {
//        PlayerController script = gameManagerScript.P4ShipPlayer.GetComponent<PlayerController>();
//        setShootHelper(script, P4ShootText);
//    }

//    public void P5SetRotate()
//    {
//        PlayerController script = gameManagerScript.P5ShipPlayer.GetComponent<PlayerController>();
//        setRotateHelper(script, P5RotateText);
//    }

//    public void P5SetShoot()
//    {
//        PlayerController script = gameManagerScript.P5ShipPlayer.GetComponent<PlayerController>();
//        setShootHelper(script, P5ShootText);
//    }

//    void setRotateHelper(PlayerController script, Text changeText)
//    {
//        KeyCode now = KeyCode.None;

//        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
//        {
//            if (Input.GetKey(kcode))
//                now = kcode;
//        }

//        script.turn = now;
//        changeText.text = now.ToString();
//    }

//    void setShootHelper(PlayerController script, Text changeText)
//    {
//        KeyCode now = KeyCode.None;

//        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
//        {
//            if (Input.GetKey(kcode))
//                now = kcode;
//        }

//        script.shoot = now;
//        changeText.text = now.ToString();
//    }
}
