using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map4LaserBeamControl : MonoBehaviour
{
    public int radius = 700;
    public GameObject indicator;
    public GameObject laserBeam;

    public List<GameObject> indicators;
    public List<GameObject> laserBeams;

    float time;
    float interval = 7.0f;

    SEManager SEManagerScript;
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SEManagerScript = GameObject.Find("SoundEffect Manager").GetComponent<SEManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameStarted)
        {
            time += Time.deltaTime;
        }

        if (time > interval)
        {
            StartCoroutine("spawnLaser");
            time = 0;
        }
    }

    public void reset()
    {
        time = 3;
        for (int i = 0; i < indicators.Count; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                indicators[i].SetActive(false);
                laserBeams[i].SetActive(false);
            }
        }
    }

    IEnumerator spawnLaser()
    {
        SEManagerScript.generalAudio.PlayOneShot(SEManagerScript.laserChargeSound);

        bool[] spawn = new bool[indicators.Count];

        for (int i = 0; i < indicators.Count; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                spawn[i] = true;
                indicators[i].SetActive(true);
            }
        }

        yield return new WaitForSeconds(2.25f);

        for (int i = 0; i < indicators.Count; i++)
        {
            if (spawn[i])
            {
                indicators[i].SetActive(false);
                laserBeams[i].SetActive(true);
            }
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < indicators.Count; i++)
        {
            if (spawn[i])
            {
                laserBeams[i].SetActive(false);
            }
        }

        float rand = Random.Range(0, 2 * Mathf.PI);

        indicator.transform.Rotate(new Vector3 (0, rand, 0));
        laserBeam.transform.Rotate(new Vector3(0, rand, 0));
    }

    void make(GameObject beam)
    {
        Vector3 endPoint1 = new Vector3(radius * Mathf.Cos(Mathf.PI / 10), 1, radius * Mathf.Sin(Mathf.PI / 10));
        Vector3 endPoint2 = new Vector3(radius * Mathf.Cos(Mathf.PI / 2), 1, radius * Mathf.Sin(Mathf.PI / 2));
        Vector3 endPoint3 = new Vector3(radius * Mathf.Cos(9 * Mathf.PI / 10), 1, radius * Mathf.Sin(9 * Mathf.PI / 10));
        Vector3 endPoint4 = new Vector3(radius * Mathf.Cos(13 * Mathf.PI / 10), 1, radius * Mathf.Sin(13 * Mathf.PI / 10));
        Vector3 endPoint5 = new Vector3(radius * Mathf.Cos(17 * Mathf.PI / 10), 1, radius * Mathf.Sin(17 * Mathf.PI / 10));

        //1 and 3
        GameObject beam1 = Instantiate(beam, new Vector3((endPoint1.x + endPoint3.x) / 2, 1, (endPoint1.z + endPoint3.z) / 2),
            transform.rotation);

        //1 and 4
        GameObject beam2 = Instantiate(beam, new Vector3((endPoint1.x + endPoint4.x) / 2, 1, (endPoint1.z + endPoint4.z) / 2),
            transform.rotation);
        beam2.transform.Rotate(new Vector3(0, -36, 0));

        //2 and 4
        GameObject beam3 = Instantiate(beam, new Vector3((endPoint2.x + endPoint4.x) / 2, 1, (endPoint2.z + endPoint4.z) / 2),
            transform.rotation);
        beam3.transform.Rotate(new Vector3(0, 90 + 36 / 2, 0));

        //2 and 5
        GameObject beam4 = Instantiate(beam, new Vector3((endPoint2.x + endPoint5.x) / 2, 1, (endPoint2.z + endPoint5.z) / 2),
            transform.rotation);
        beam4.transform.Rotate(new Vector3(0, 36 * 2, 0));

        //3 and 5
        GameObject beam5 = Instantiate(beam, new Vector3((endPoint3.x + endPoint5.x) / 2, 1, (endPoint3.z + endPoint5.z) / 2),
            transform.rotation);
        beam5.transform.Rotate(new Vector3(0, 36, 0));
    }
}
