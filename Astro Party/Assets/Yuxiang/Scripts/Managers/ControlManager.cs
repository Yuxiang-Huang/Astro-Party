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
        team = id;

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
        List<GameObject> ship = gameManagerScript.ships[team-1];
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

        gameManagerScript.ships[team-1].Remove(curr);
        team++;

        if (team == 5)
        {
            team = 0;
        }
        gameManagerScript.ships[team-1].Add(curr);

        teamText.text = team.ToString();
    }

    GameObject findShip(int team, GameObject shipTarget, GameObject bot)
    {
        GameObject ans = null;
        List<GameObject> ship = gameManagerScript.ships[team-1];
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

    public void setRotate()
    {
        KeyCode now = KeyCode.None;

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                now = kcode;
        }

        shipPlayer.GetComponent<PlayerController>().turn = now;
        rotateText.text = now.ToString();
    }

    public void setShoot()
    {
        KeyCode now = KeyCode.None;

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                now = kcode;
        }

        shipPlayer.GetComponent<PlayerController>().shoot = now;
        shootText.text = now.ToString();
    }
}
