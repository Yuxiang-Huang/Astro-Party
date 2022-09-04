using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public List<GameObject> indicators = new List<GameObject>();

    public AudioClip shipExplode;

    public AudioClip laserSound;
    public GameObject laser;

    public AudioClip bulletSound;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPowerUp()
    {
        int ran = Random.Range(0, indicators.Count);
        Instantiate(indicators[ran], new Vector3(0, 0, 0), indicators[ran].transform.rotation);
    }
}
