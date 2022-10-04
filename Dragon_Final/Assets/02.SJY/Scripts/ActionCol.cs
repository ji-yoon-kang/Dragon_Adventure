using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Controller") && !DragonMovement.Instance.isfly)
        {
            DragonMovement.Instance.anim.SetTrigger("Die");
            if (DragonSoundManager.instance.flysound.isPlaying == false)
            {
                DragonSoundManager.instance.flysound.clip = DragonSoundManager.instance.soundclips[5];
                DragonSoundManager.instance.flysound.Play();
            }
        }
    }
   
    
}
