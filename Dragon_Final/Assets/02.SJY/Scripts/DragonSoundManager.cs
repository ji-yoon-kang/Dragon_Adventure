using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSoundManager : MonoBehaviour
{
    public static DragonSoundManager instance;
    // Start is called before the first frame update
    public AudioSource flysound;
    public AudioClip[] soundclips;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        flysound = GetComponent<AudioSource>();
        soundclips = new AudioClip[18];
        soundclips = Resources.LoadAll<AudioClip>("AdultDragonSound");
        //DragonSoundManager.instance.flysound.clip = DragonSoundManager.instance.soundclips[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
