using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour
{
    public GameObject player;
    public float startPosition;
    int distance = 250;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startPosition += Time.deltaTime;
        transform.position = new Vector3(player.transform.position.x + Mathf.Cos(startPosition) * distance,
            player.transform.position.y, player.transform.position.z + Mathf.Sin(startPosition) * distance);
    }
}
