using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> ships = new List<GameObject> ();

    public GameObject blueShipPlayer;
    public GameObject blueShipBot;
    public GameObject blueTextPlayer;
    public GameObject blueTextBot;
    public GameObject blueTextOff;

    public GameObject redShipPlayer;
    public GameObject redShipBot;
    public GameObject redTextPlayer;
    public GameObject redTextBot;
    public GameObject redTextOff;

    public GameObject yellowShipPlayer;
    public GameObject yellowShipBot;
    public GameObject yellowTextPlayer;
    public GameObject yellowTextBot;
    public GameObject yellowTextOff;

    public GameObject cyanShipPlayer;
    public GameObject cyanShipBot;
    public GameObject cyanTextPlayer;
    public GameObject cyanTextBot;
    public GameObject cyanTextOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void P1Button()
    {
        buttonHelper(blueShipPlayer, blueShipBot, blueTextPlayer, blueTextBot, blueTextOff);
    }

    public void P2Button()
    {
        buttonHelper(redShipPlayer, redShipBot, redTextPlayer, redTextBot, redTextOff);
    }

    public void P3Button()
    {
        buttonHelper(yellowShipPlayer, yellowShipBot, yellowTextPlayer, yellowTextBot, yellowTextOff);
    }

    public void P4Button()
    {
        buttonHelper(cyanShipPlayer, cyanShipBot, cyanTextPlayer, cyanTextBot, cyanTextOff);
    }

    void buttonHelper(GameObject player, GameObject bot, GameObject textPlayer, GameObject textBot, GameObject textOff)
    {
        if (ships.Contains(player))
        {
            textPlayer.SetActive(false);
            textBot.SetActive(true);
            ships.Remove(player);
            ships.Add(bot);
        }
        else if (ships.Contains(bot))
        {
            textBot.SetActive(false);
            textOff.SetActive(true);
            ships.Remove(bot);
        }
        else
        {
            textOff.SetActive(false);
            textPlayer.SetActive(true);
            ships.Add(player);
        }
    }
}
