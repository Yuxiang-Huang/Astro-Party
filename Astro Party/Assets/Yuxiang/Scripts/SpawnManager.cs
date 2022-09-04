using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> indicators = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(indicators[0], new Vector3(0, 0, 0), indicators[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
