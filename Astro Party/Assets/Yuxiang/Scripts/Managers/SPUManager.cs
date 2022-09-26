using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPUManager : MonoBehaviour
{
    public int id;

    GameManager gameManagerScript;

    public Text RandomSPUText;
    public Text SPUCurrText;
    public Text SPULaserText;
    public Text SPUScatterText;
    public Text SPUTripleText;
    public Text SPUFreezerText;
    public Text SPUShieldText;
    public Text SPUMineText;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    void setHelper(string modeString, Text modeText, int id)
    {
        foreach (List<GameObject> shipList in gameManagerScript.ships)
        {
            foreach (GameObject ship in shipList)
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
    }

    //Triple Shot

    public void setTripleSPU()
    {
        setTripleHelper(id, SPUTripleText);
    }

    void setTripleHelper(int id, Text modeText)
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
                        modeText.text = "Triple Shot: Off";
                    }
                    else
                    {
                        script.tripleShot = true;
                        modeText.text = "Triple Shot: On";
                    }
                }
            }
        }
    }

    //Shield

    public void setShieldSPU()
    {
        setShiledHelper(id, SPUShieldText);
    }

    void setShiledHelper(int id, Text modeText)
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
                        modeText.text = "Shield: Off";
                    }
                    else
                    {
                        script.hasShield = true;
                        modeText.text = "Shield: On";
                    }
                }
            }
        }
    }
}
