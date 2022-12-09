using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSPUManager : MonoBehaviour
{
    public List<GameObject> SPUPlayers;

    //string currMode;

    //public Text title;
    //public Text AllRandomSPUText;
    //public Text AllSPULaserText;
    //public Text AllSPUScatterText;
    //public Text AllSPUTripleText;
    //public Text AllSPUFreezerText;
    //public Text AllSPUShieldText;
    //public Text AllSPUMineText;
    //public Text AllSPUBBText;
    //public Text AllSPUJousterText;

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
        setHelper("Random Starting PowerUp");
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

    void setHelper(string modeString)
    {
        Dictionary<string, Text> textToUse = new Dictionary<string, Text>();

        if (modeString == "Random Starting PowerUp")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.RandomSPUText, script.id);
            }
        }

        else if (modeString == "Laser Beam")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.SPULaserText, script.id);
            }
        }

        else if (modeString == "Scatter Shot")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.SPUScatterText, script.id);
            }
        }

        else if (modeString == "Freezer")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.SPUFreezerText, script.id);
            }
        }

        else if (modeString == "Proximity Mine")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.SPUMineText, script.id);
            }
        }

        else if (modeString == "Bouncy Bullet")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.SPUBBText, script.id);
            }
        }

        else if (modeString == "Jouster")
        {
            foreach (GameObject SPU in SPUPlayers)
            {
                SPUManager script = SPU.GetComponent<SPUManager>();
                script.setOnHelper(modeString, script.SPUJousterText, script.id);
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
