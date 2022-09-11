using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera myCamera;
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float minX = -gameManagerScript.spawnX;
        float maxX = gameManagerScript.spawnX;
        float minZ = -gameManagerScript.spawnZ;
        float maxZ = gameManagerScript.spawnZ;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                minX = Mathf.Min(minX, ship.transform.position.x);
                maxX = Mathf.Max(maxX, ship.transform.position.x);
                minZ = Mathf.Min(minZ, ship.transform.position.z);
                maxZ = Mathf.Max(maxZ, ship.transform.position.z);
            }
        }

        Debug.Log(minX);
        Debug.Log(minZ);
        Debug.Log(maxX);
        Debug.Log(maxZ);
    }
}
