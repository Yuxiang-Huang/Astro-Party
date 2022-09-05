using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        indicators.Add(laserIndicator);
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
            if (script.shootMode == "laser")
            {
                Instantiate(laserIndicator, script.transform.position, laserIndicator.transform.rotation);
            }
        }
    }

    //Players

    public void setLaserP1()
    {

    }
}
