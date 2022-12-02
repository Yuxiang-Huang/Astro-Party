using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPUManager : MonoBehaviour
{
    public int id;

    GameManager gameManagerScript;

    public Text title;
    public Text RandomSPUText;
    public Text SPUCurrText;
    public Text SPULaserText;
    public Text SPUScatterText;
    public Text SPUTripleText;
    public Text SPUFreezerText;
    public Text SPUShieldText;
    public Text SPUMineText;
    public Text SPUBBText;
    public Text SPUJousterText;

    // Start is called before the first frame update
    void Awake()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        title.text = "P" + id + " Starting Power Up";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRandomSPU()
    {
        setHelper("Random Starting PowerUp", RandomSPUText, id);
    }

    public void setLaserSPU()
    {
        setHelper("Laser Beam", SPULaserText, id);
    }

    public void setScatterSPU()
    {
        setHelper("Scatter Shot", SPUScatterText, id);
    }

    public void setFreezerSPU()
    {
        setHelper("Freezer", SPUFreezerText, id);
    }

    public void setMineSPU()
    {
        setHelper("Proximity Mine", SPUMineText, id);
    }

    public void setBBSPU()
    {
        setHelper("Bouncy Bullet", SPUBBText, id);
    }

    public void setJousterSPU()
    {
        setHelper("Jouster", SPUJousterText, id);
    }

    void setHelper(string modeString, Text modeText, int id)
    {
        foreach (GameObject ship in gameManagerScript.allShips)
        {
            MutualShip script = ship.GetComponent<MutualShip>();
            if (script.id == id)
            {
                //to set last powerUpText off
                if (script.shootMode == modeString)
                {
                    script.shootMode = "normal";
                    modeText.text = modeString + ": Off";
                    SPUCurrText = null;
                }
                else
                {
                    if (SPUCurrText != null)
                    {
                        SPUCurrText.text = script.shootMode + ": Off";
                    }

                    script.shootMode = modeString;
                    modeText.text = modeString + ": On";

                    SPUCurrText = modeText;
                }
            }
        }
    }

    //Triple Shot

    public void setTripleSPU()
    {
        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
            {
                MutualShip script = ship.GetComponent<MutualShip>();
                if (script.id == id)
                {
                    if (script.tripleShot)
                    {
                        script.tripleShot = false;
                        SPUTripleText.text = "Triple Shot: Off";
                    }
                    else
                    {
                        script.tripleShot = true;
                        SPUTripleText.text = "Triple Shot: On";
                    }
                }
            }
        }
    }

    //Shield

    public void setShieldSPU()
    {
        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
            {
                MutualShip script = ship.GetComponent<MutualShip>();
                if (script.id == id)
                {
                    if (script.hasShield)
                    {
                        script.hasShield = false;
                        SPUShieldText.text = "Shield: Off";
                    }
                    else
                    {
                        script.hasShield = true;
                        SPUShieldText.text = "Shield: On";
                    }
                }
            }
        }
    }
}
