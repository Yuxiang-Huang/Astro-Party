using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSPUManager : MonoBehaviour
{
    public List<GameObject> SPUPlayers;

    public Text title;
    public Text AllRandomSPUText;
    public Text AllSPUCurrText;
    public Text AllSPULaserText;
    public Text AllSPUScatterText;
    public Text AllSPUTripleText;
    public Text AllSPUFreezerText;
    public Text AllSPUShieldText;
    public Text AllSPUMineText;
    public Text AllSPUBBText;
    public Text AllSPUJousterText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setRandomAllSPU()
    {
        setHelper("Random Starting PowerUp", AllRandomSPUText);
    }

    //public void setLaserAllSPU()
    //{
    //    setHelper("Laser Beam", AllSPULaserText, id);
    //}

    //public void setScatterAllSPU()
    //{
    //    setHelper("Scatter Shot", AllSPUScatterText, id);
    //}

    //public void setFreezerAllSPU()
    //{
    //    setHelper("Freezer", AllSPUFreezerText, id);
    //}

    //public void setMineAllSPU()
    //{
    //    setHelper("Proximity Mine", AllSPUMineText, id);
    //}

    //public void setBBAllSPU()
    //{
    //    setHelper("Bouncy Bullet", AllSPUBBText, id);
    //}

    //public void setJousterAllSPU()
    //{
    //    setHelper("Jouster", AllSPUJousterText, id);
    //}

    void setHelper(string modeString, Text modeText)
    {
        if (modeString == "Random Starting PowerUp")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPU.GetComponent<SPUManager>().setRandomSPU();
            }
        }
    }

    ////Triple Shot

    //public void setTripleAllSPU()
    //{
    //    foreach (List<GameObject> shipList in gameManagerScript.ships)
    //    {
    //        foreach (GameObject ship in shipList)
    //        {
    //            MutualShip script = ship.GetComponent<MutualShip>();
    //            if (script.id == id)
    //            {
    //                if (script.tripleShot)
    //                {
    //                    script.tripleShot = false;
    //                    AllSPUTripleText.text = "Triple Shot: Off";
    //                }
    //                else
    //                {
    //                    script.tripleShot = true;
    //                    AllSPUTripleText.text = "Triple Shot: On";
    //                }
    //            }
    //        }
    //    }
    //}

    ////Shield

    //public void setShieldAllSPU()
    //{
    //    foreach (List<GameObject> shipList in gameManagerScript.ships)
    //    {
    //        foreach (GameObject ship in shipList)
    //        {
    //            MutualShip script = ship.GetComponent<MutualShip>();
    //            if (script.id == id)
    //            {
    //                if (script.hasShield)
    //                {
    //                    script.hasShield = false;
    //                    AllSPUShieldText.text = "Shield: Off";
    //                }
    //                else
    //                {
    //                    script.hasShield = true;
    //                    AllSPUShieldText.text = "Shield: On";
    //                }
    //            }
    //        }
    //    }
    //}
}
