using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public List<GameObject> indicators = new List<GameObject>();
    public List<string> SPU = new List<string>();

    public int powerUpyValue = 30;

    public GameObject bullet;

    public int maxPowerUp = 1;
    public Text maxPowerUpText;

    public bool allRandomSPU;
    public Text allRandomSPUText;
    public Text P1RandomSPUText;
    public Text P2RandomSPUText;
    public Text P3RandomSPUText;
    public Text P4RandomSPUText;
    public Text P5RandomSPUText;

    public Text P1CurrText;
    public Text P2CurrText;
    public Text P3CurrText;
    public Text P4CurrText;
    public Text P5CurrText;

    public GameObject laser;
    public GameObject laserIndicator;
    public Text laserText;
    public Text P1LaserText;
    public Text P2LaserText;
    public Text P3LaserText;
    public Text P4LaserText;
    public Text P5LaserText;

    public GameObject scatterIndicator;
    public Text scatterText;
    public Text P1scatterText;
    public Text P2scatterText;
    public Text P3scatterText;
    public Text P4scatterText;
    public Text P5scatterText;

    public GameObject tripleShotIndicator;
    public Text tripleText;
    public Text P1TripleText;
    public Text P2TripleText;
    public Text P3TripleText;
    public Text P4TripleText;
    public Text P5TripleText;

    public GameObject freezer;
    public GameObject freezerIndicator;
    public Text freezerText;
    public Text P1FreezerText;
    public Text P2FreezerText;
    public Text P3FreezerText;
    public Text P4FreezerText;
    public Text P5FreezerText;

    public GameObject shieldIndicator;
    public Text shieldText;
    public Text P1ShieldText;
    public Text P2ShieldText;
    public Text P3ShieldText;
    public Text P4ShieldText;
    public Text P5ShieldText;

    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        indicators.Add(laserIndicator);
        indicators.Add(scatterIndicator);
        indicators.Add(tripleShotIndicator);
        indicators.Add(freezerIndicator);
        indicators.Add(shieldIndicator);

        SPU.Add("Laser Beam");
        SPU.Add("Scatter Shot");
        SPU.Add("Freezer");

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Starting Power Up

    public void setRandomSPUAll()
    {
        if (allRandomSPU)
        {
            allRandomSPUText.text = "Random Starting PowerUp: Off";
        }
        else
        {
            allRandomSPUText.text = "Random Starting PowerUp: On";
        }

        allRandomSPU = !allRandomSPU;
    }

    public void setRandomSPUP1()
    {
        setHelper("Random Starting PowerUp", P1RandomSPUText, 1);
    }

    public void setRandomSPUP2()
    {
        setHelper("Random Starting PowerUp", P2RandomSPUText, 2);
    }

    public void setRandomSPUP3()
    {
        setHelper("Random Starting PowerUp", P3RandomSPUText, 3);
    }

    public void setRandomSPUP4()
    {
        setHelper("Random Starting PowerUp", P4RandomSPUText, 4);
    }

    public void setRandomSPUP5()
    {
        setHelper("Random Starting PowerUp", P5RandomSPUText, 5);
    }

    //PowerUP

    public void setTriplePowerUp()
    {
        if (maxPowerUp == 1)
        {
            maxPowerUp = 3;
            maxPowerUpText.text = "Triple PowerUp: On";
        }
        else
        {
            maxPowerUp = 1;
            maxPowerUpText.text = "Triple PowerUp: Off";
        }
    }
    

    public void setLaser()
    {
        if (indicators.Contains(laserIndicator))
        {
            indicators.Remove(laserIndicator);
            SPU.Remove("Laser Beam");
            laserText.text = "Laser Beam: Off";
        }
        else
        {
            indicators.Add(laserIndicator);
            SPU.Add("Laser Beam");
            laserText.text = "Laser Beam: On";
        }
    }

    public void setScatterShot()
    {
        if (indicators.Contains(scatterIndicator))
        {
            indicators.Remove(scatterIndicator);
            SPU.Remove("Scatter Shot");
            scatterText.text = "Scatter Shot: Off";
        }
        else
        {
            indicators.Add(scatterIndicator);
            SPU.Add("Scatter Shot");
            scatterText.text = "Scatter Shot: On";
        }
    }

    public void setTripleShot()
    {
        if (indicators.Contains(tripleShotIndicator))
        {
            indicators.Remove(tripleShotIndicator);
            tripleText.text = "Triple Shot: Off";
        }
        else
        {
            indicators.Add(tripleShotIndicator);
            tripleText.text = "Triple Shot: On";
        }
    }

    public void setFreezer()
    {
        if (indicators.Contains(freezerIndicator))
        {
            indicators.Remove(freezerIndicator);
            SPU.Remove("Freezer");
            freezerText.text = "Freezer: Off";
        }
        else
        {
            indicators.Add(freezerIndicator);
            SPU.Add("Freezer");
            freezerText.text = "Freezer: On";
        }
    }

    public void setShield()
    {
        if (indicators.Contains(shieldIndicator))
        {
            indicators.Remove(shieldIndicator);
            shieldText.text = "Shield: Off";
        }
        else
        {
            indicators.Add(shieldIndicator);
            shieldText.text = "Shield: On";
        }
    }

    public void dropItem(MutualShip script)
    {
        if (script.shootMode != "normal")
        {
            switch (script.shootMode)
            {
                case "Laser Beam":
                    GameObject toAdd = Instantiate(laserIndicator,
                        new Vector3(script.transform.position.x, powerUpyValue, script.transform.position.z),
                        laserIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd);
                    break;
                case "Scatter Shot":
                    GameObject toAdd1 = Instantiate(scatterIndicator,
                        new Vector3(script.transform.position.x, powerUpyValue, script.transform.position.z),
                        scatterIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd1);
                    break;
                case "Freezer":
                    GameObject toAdd2 = Instantiate(freezerIndicator,
                        new Vector3(script.transform.position.x, powerUpyValue, script.transform.position.z),
                        freezerIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd2);
                    break;
            }
        }
    }

    //Players
    //Laser Beam
    public void setLaserP1()
    {
        setHelper("Laser Beam", P1LaserText, 1);
    }

    public void setLaserP2()
    {
        setHelper("Laser Beam", P2LaserText, 2);
    }

    public void setLaserP3()
    {
        setHelper("Laser Beam", P3LaserText, 3);
    }

    public void setLaserP4()
    {
        setHelper("Laser Beam", P4LaserText, 4);
    }

    public void setLaserP5()
    {
        setHelper("Laser Beam", P5LaserText, 5);
    }

    //Scatter Shot

    public void setScatterP1()
    {
        setHelper("Scatter Shot", P1scatterText, 1);
    }

    public void setScatterP2()
    {
        setHelper("Scatter Shot", P2scatterText, 2);
    }

    public void setScatterP3()
    {
        setHelper("Scatter Shot", P3scatterText, 3);
    }

    public void setScatterP4()
    {
        setHelper("Scatter Shot", P4scatterText, 4);
    }

    public void setScatterP5()
    {
        setHelper("Scatter Shot", P5scatterText, 5);
    }

    //Freezer

    public void setFreezerP1()
    {
        setHelper("Freezer", P1FreezerText, 1);
    }

    public void setFreezerP2()
    {
        setHelper("Freezer", P2FreezerText, 2);
    }

    public void setFreezerP3()
    {
        setHelper("Freezer", P3FreezerText, 3);
    }

    public void setFreezerP4()
    {
        setHelper("Freezer", P4FreezerText, 4);
    }

    public void setFreezerP5()
    {
        setHelper("Freezer", P5FreezerText, 5);
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
                        switch (id)
                        {
                            case 1:
                                P1CurrText = null;
                                break;
                            case 2:
                                P2CurrText = null;
                                break;
                            case 3:
                                P3CurrText = null;
                                break;
                            case 4:
                                P4CurrText = null;
                                break;
                            case 5:
                                P5CurrText = null;
                                break;
                        }
                    }
                    else
                    { 
                        switch (id)
                        {
                            case 1:
                                if (P1CurrText != null)
                                    P1CurrText.text = script.shootMode + ": Off";
                                break;
                            case 2:
                                if (P2CurrText != null)
                                    P2CurrText.text = script.shootMode + ": Off";
                                break;
                            case 3:
                                if (P3CurrText != null)
                                    P3CurrText.text = script.shootMode + ": Off";
                                break;
                            case 4:
                                if (P4CurrText != null)
                                    P4CurrText.text = script.shootMode + ": Off";
                                break;
                            case 5:
                                if (P5CurrText != null)
                                    P5CurrText.text = script.shootMode + ": Off";
                                break;
                        }

                        script.shootMode = modeString;
                        modeText.text = modeString + ": On";

                        switch (id)
                        {
                            case 1: P1CurrText = modeText; break;
                            case 2: P2CurrText = modeText; break;
                            case 3: P3CurrText = modeText; break;
                            case 4: P4CurrText = modeText; break;
                            case 5: P5CurrText = modeText; break;
                        }
                    }
                }
            }
        }
    }

    //Triple Shot

    public void setTripleP1()
    {
        setTripleHelper(1, P1TripleText);
    }

    public void setTripleP2()
    {
        setTripleHelper(2, P2TripleText);
    }

    public void setTripleP3()
    {
        setTripleHelper(3, P3TripleText);
    }

    public void setTripleP4()
    {
        setTripleHelper(4, P4TripleText);
    }

    public void setTripleP5()
    {
        setTripleHelper(5, P5TripleText);
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

    public void setShieldP1()
    {
        setShiledHelper(1, P1ShieldText);
    }

    public void setShieldP2()
    {
        setShiledHelper(2, P2ShieldText);
    }

    public void setShieldP3()
    {
        setShiledHelper(3, P3ShieldText);
    }

    public void setShieldP4()
    {
        setShiledHelper(4, P4ShieldText);
    }

    public void setShieldP5()
    {
        setShiledHelper(5, P5ShieldText);
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
