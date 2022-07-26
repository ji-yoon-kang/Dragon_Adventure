using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishText : MonoBehaviour
{
    public GameObject noFish;

    void Start()
    {
        noFish.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            Invoke("NoFish", 2f);
            //NoFish();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Water")
        {
            Invoke("NoFishOff", 2f);
        }
    }

    private void NoFish()
    {
        noFish.SetActive(true);
    }

    private void NoFishOff()
    {
        noFish.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
