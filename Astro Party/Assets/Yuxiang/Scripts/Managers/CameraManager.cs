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

    void LateUpdate()
    {
        int space = 100;

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

        float lenX = (maxX - minX) / 2;

        float lenZ = (maxZ - minZ) / 2;

        //Debug.Log("minX before: " + minX);

        minX = Mathf.Max(minX - lenX, -gameManagerScript.spawnRadius);
        maxX = Mathf.Min(maxX + lenX, gameManagerScript.spawnRadius);

        minZ = Mathf.Max(minZ - lenZ, -gameManagerScript.spawnRadius);
        maxZ = Mathf.Min(maxZ + lenZ, gameManagerScript.spawnRadius);

        myCamera.orthographicSize = Mathf.Max(500, Mathf.Max((maxX - minX), (maxZ - minZ))) / 2;

        transform.position = new Vector3((minX + maxX) / 2, transform.position.y, (minZ + maxZ) / 2);

        //Debug.Log("minX after: " + minX);
        //Debug.Log("minZ: " + minZ);
        //Debug.Log("maxX: " + maxX);
        //Debug.Log("maxZ: " + maxZ);
    }
}
