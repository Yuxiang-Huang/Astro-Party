using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public List<GameObject> indicators = new List<GameObject>();

    public AudioClip shipExplode;

    public AudioClip bulletSound;
    public GameObject bullet;

    public AudioClip laserSound;
    public GameObject laser;
    public GameObject laserIndicator;
    public GameObject laserButtonOn;
    public GameObject laserButtonOff;

    public Text P1LaserText;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        indicators.Add(laserIndicator);
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPowerUp()
    {
        if (indicators.Count > 0)
        {
            int ran = Random.Range(0, indicators.Count);
            Instantiate(indicators[ran], new Vector3(0, 0, 0), indicators[ran].transform.rotation);
        }
    }

    public void setLaserOn()
    {
        indicators.Add(laserIndicator);
        laserButtonOff.SetActive(false);
        laserButtonOn.SetActive(true);
    }

    public void setLaserOff()
    {
        indicators.Remove(laserIndicator);
        laserButtonOn.SetActive(false);
        laserButtonOff.SetActive(true);
    }

    public void dropItem(MutualShip script)
    {
        if (script.shootMode != "normal")
        {
            switch (script.shootMode)
            {
                case "Laser Beam":
                    Instantiate(laserIndicator, script.transform.position, laserIndicator.transform.rotation);
                    break;
            }
        }
    }

    //Players

    public void setLaserP1()
    {
        setHelper("Laser Beam", P1LaserText, 1);
    }

    void setHelper(string modeString, Text modeText, int id)
    {
        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
            {
                MutualShip script = ship.GetComponent<MutualShip>();
                if (script.id == id)
                {
                    if (script.shootMode == modeString)
                    {
                        script.shootMode = "normal";
                        modeText.text = modeString + ": Off";
                    }
                    else
                    {
                        script.shootMode = modeString;
                        modeText.text = modeString + ": On";
                    }
                }
            }
        }
    }
}
