using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittleDragonLV : MonoBehaviour
{
    public GameObject dlvUI;
    public int maxLV = 20;
    public int minLV = 0;
    int lv;
    public Slider sliderLV;

    public static LittleDragonLV instance;
    private void Awake()
    {
        instance = this;
    }

    public int LV
    {
        get { return lv; }
        set {
            lv = value;
            sliderLV.value = lv;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sliderLV.minValue = 0;
        LV = minLV;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
