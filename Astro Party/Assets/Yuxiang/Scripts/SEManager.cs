using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioSource generalAudio;

    public AudioClip shipExplode;
    public AudioClip pilotDeath;
    public AudioClip ready;

    public AudioClip bulletSound;

    public AudioClip laserSound;

    public AudioClip freezerSound;

    // Start is called before the first frame update
    void Start()
    {
        generalAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
