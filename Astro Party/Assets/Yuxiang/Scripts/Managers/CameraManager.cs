using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera myCamera;
    GameManager gameManagerScript;

    public int space = 50;

    public float itchScreenFactor = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void LateUpdate()
    {
        float minX = gameManagerScript.spawnRadius;
        float maxX = -gameManagerScript.spawnRadius;
        float minZ = gameManagerScript.spawnRadius;
        float maxZ = -gameManagerScript.spawnRadius;

        foreach (List<GameObject> shipList in gameManagerScript.inGameShips)
        {
            foreach (GameObject ship in shipList)
            {
                if (ship != null)
                {
                    minX = Mathf.Min(minX, ship.transform.position.x) - space;
                    maxX = Mathf.Max(maxX, ship.transform.position.x) + space;
                    minZ = Mathf.Min(minZ, ship.transform.position.z) - space;
                    maxZ = Mathf.Max(maxZ, ship.transform.position.z) + space;
                }
            }
        }

        minX = Mathf.Max(minX, -gameManagerScript.spawnRadius - space);
        maxX = Mathf.Min(maxX, gameManagerScript.spawnRadius + space);

        minZ = Mathf.Max(minZ, -gameManagerScript.spawnRadius - space);
        maxZ = Mathf.Min(maxZ, gameManagerScript.spawnRadius + space);

        myCamera.orthographicSize = Mathf.Max(500, Mathf.Max((maxX - minX) / itchScreenFactor, (maxZ - minZ))) / 2;

        transform.position = new Vector3((minX + maxX) / 2, transform.position.y, (minZ + maxZ) / 2);

        //Debug.Log("minX after: " + minX);
        //Debug.Log("minZ: " + minZ);
        //Debug.Log("maxX: " + maxX);
        //Debug.Log("maxZ: " + maxZ);
    }
}
