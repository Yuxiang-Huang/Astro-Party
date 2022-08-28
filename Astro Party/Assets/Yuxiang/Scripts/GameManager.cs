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
