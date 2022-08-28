using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> ships = new List<GameObject> ();
    List<GameObject> inGameShips = new List<GameObject>();
    List<Vector3> pos;
    List<Vector3> rot;

    public GameObject nextButton;

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

    int spawnX = 850;
    int spawnZ = 400;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
        pos = new List<Vector3>() { new Vector3(spawnX, 30, spawnZ), new Vector3(-spawnX, 30, spawnZ),
        new Vector3(spawnX, 30, -spawnZ), new Vector3(-spawnX, 30, -spawnZ)};
        rot = new List<Vector3>() {new Vector3(0, 180, 0), new Vector3(0, 90, 0),
        new Vector3(0, -90, 0), new Vector3(0, 0, 0)};
    }

    // Update is called once per frame
    void Update()
    {
        if (ships.Count >= 2)
        { 
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
    }

    public void spawnShips()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            int ran = Random.Range(0, pos.Count);
            inGameShips.Add(Instantiate(ships[i], pos[ran], ships[i].transform.rotation));
            inGameShips[i].transform.Rotate(rot[ran]);
            pos.RemoveAt(ran);
            rot.RemoveAt(ran);
        }
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
