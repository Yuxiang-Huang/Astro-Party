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
        int space = 30;

        float minX = gameManagerScript.spawnX;
        float maxX = -gameManagerScript.spawnX;
        float minZ = gameManagerScript.spawnZ;
        float maxZ = -gameManagerScript.spawnZ;

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

        //float lenX = (maxX - minX) / 2;

        //float lenZ = (maxZ - minZ) / 2;

        //Debug.Log("minX before: " + minX);

        //minX = Mathf.Max(minX - lenX, -gameManagerScript.spawnX - 100);
        //maxX = Mathf.Min(maxX + lenX, gameManagerScript.spawnX + 100);

        //minZ = Mathf.Max(minZ - lenZ, -gameManagerScript.spawnZ - 100);
        //maxZ = Mathf.Min(maxZ + lenZ, gameManagerScript.spawnZ + 100);

        myCamera.orthographicSize = Mathf.Max(500, Mathf.Max((maxX - minX), (maxZ - minZ))) / 2;

        transform.position = new Vector3((minX + maxX) / 2, transform.position.y, (minZ + maxZ) / 2);

        //Debug.Log("minX after: " + minX);
        //Debug.Log("minZ: " + minZ);
        //Debug.Log("maxX: " + maxX);
        //Debug.Log("maxZ: " + maxZ);
    }
}
