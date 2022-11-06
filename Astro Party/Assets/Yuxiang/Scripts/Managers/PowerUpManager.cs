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

    bool isAutoBalance;
    public Text autoBalanceText;

    public int maxPowerUp = 1;
    public Text maxPowerUpText;

    public bool allRandomSPU;
    public Text allRandomSPUText;

    public GameObject laser;
    public GameObject laserIndicator;
    public Text laserText;

    public GameObject scatterIndicator;
    public Text scatterText;

    public GameObject tripleShotIndicator;
    public Text tripleText;

    public GameObject freezer;
    public GameObject freezerIndicator;
    public Text freezerText;

    public GameObject shieldIndicator;
    public Text shieldText;

    public GameObject mine;
    public GameObject mineIndicator;
    public Text mineText;

    public GameObject bouncyBullet;
    public GameObject BBIndicator;
    public Text BBText;

    public GameObject jousterIndicator;
    public Text jousterText;

    GameManager gameManagerScript;
    ScoreManager scoreManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        indicators.Add(laserIndicator);
        indicators.Add(scatterIndicator);
        //indicators.Add(tripleShotIndicator);
        indicators.Add(freezerIndicator);
        indicators.Add(shieldIndicator);
        indicators.Add(mineIndicator);
        indicators.Add(BBIndicator);
        indicators.Add(jousterIndicator);

        SPU.Add("Laser Beam");
        SPU.Add("Scatter Shot");
        SPU.Add("Freezer");
        SPU.Add("Proximity Mine");
        SPU.Add("Bouncy Bullet");
        SPU.Add("Jouster");

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreManagerScript = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Auto Balance
    public void setAutoBalance()
    {
        if (isAutoBalance)
        {
            autoBalanceText.text = "Auto Balance: Off";
        }
        else
        {
            autoBalanceText.text = "Auto Balance: On";
        }
        isAutoBalance = !isAutoBalance;
    }

    public void autoBalance()
    {
        if (isAutoBalance)
        {
            //find maxScore
            int maxScore = scoreManagerScript.P1Score;
            maxScore = Mathf.Max(maxScore, scoreManagerScript.P2Score);
            maxScore = Mathf.Max(maxScore, scoreManagerScript.P3Score);
            maxScore = Mathf.Max(maxScore, scoreManagerScript.P4Score);
            maxScore = Mathf.Max(maxScore, scoreManagerScript.P5Score);

            //helper
            foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
            {
                foreach (GameObject ship in shipList)
                {
                    switch (ship.GetComponent<MutualShip>().id)
                    {
                        case 1:
                            getPowerUp(scoreManagerScript.P1Score, maxScore, ship.GetComponent<MutualShip>());
                            break;
                        case 2:
                            getPowerUp(scoreManagerScript.P2Score, maxScore, ship.GetComponent<MutualShip>());
                            break;
                        case 3:
                            getPowerUp(scoreManagerScript.P3Score, maxScore, ship.GetComponent<MutualShip>());
                            break;
                        case 4:
                            getPowerUp(scoreManagerScript.P4Score, maxScore, ship.GetComponent<MutualShip>());
                            break;
                        case 5:
                            getPowerUp(scoreManagerScript.P5Score, maxScore, ship.GetComponent<MutualShip>());
                            break;
                    }
                }
            }
        }
    }

    void getPowerUp(int score, int maxScore, MutualShip script)
    {
        if (score < maxScore - 1)
        {
            script.hasShield = true;
        }
        if (score < maxScore - 2)
        {
            script.tripleShot = true;
        }
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

    public void setMine()
    {
        if (indicators.Contains(mineIndicator))
        {
            indicators.Remove(mineIndicator);
            SPU.Remove("Proximity Mine");
            mineText.text = "Proximity Mine: Off";
        }
        else
        {
            indicators.Add(mineIndicator);
            SPU.Add("Proximity Mine");
            mineText.text = "Proximity Mine: On";
        }
    }

    public void setBB()
    {
        if (indicators.Contains(BBIndicator))
        {
            indicators.Remove(BBIndicator);
            SPU.Remove("Bouncy Bullet");
            BBText.text = "Bouncy Bullet: Off";
        }
        else
        {
            indicators.Add(BBIndicator);
            SPU.Add("Bouncy Bullet");
            BBText.text = "Bouncy Bullet: On";
        }
    }

    public void setJouster()
    {
        if (indicators.Contains(jousterIndicator))
        {
            indicators.Remove(jousterIndicator);
            SPU.Remove("Jouster");
            jousterText.text = "Jouster: Off";
        }
        else
        {
            indicators.Add(jousterIndicator);
            SPU.Add("Jouster");
            jousterText.text = "Jouster: On";
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
                case "Proximity Mine":
                    GameObject toAdd3 = Instantiate(mineIndicator,
                        new Vector3(script.transform.position.x, powerUpyValue, script.transform.position.z),
                        mineIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd3);
                    break;
                case "Jouster":
                    GameObject toAdd4 = Instantiate(jousterIndicator,
                        new Vector3(script.transform.position.x, powerUpyValue, script.transform.position.z),
                        mineIndicator.transform.rotation);
                    gameManagerScript.inGameIndicators.Add(toAdd4);
                    break;
            }
        }
    }
}
