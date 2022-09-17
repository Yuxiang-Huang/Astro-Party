using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public bool fixedSpawn;
    public Text fixedSpawnText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFixedSpawn()
    {
        if (fixedSpawn)
        {
            fixedSpawnText.text = "Fixed Spawn: Off";
        }
        else
        {
            fixedSpawnText.text = "Fixed Spawn: On";
        }
        fixedSpawn = !fixedSpawn;
    }
}
