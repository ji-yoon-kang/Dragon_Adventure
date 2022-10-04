using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager instance = null;

    public int ranvalue;

    public void Awake()
    {
        instance = this;
    }

    public Transform[] wayPoints;

    void Start()
    {
                 
    }

    public int SetRanValue()
    {
        ranvalue = Random.Range(0, wayPoints.Length);

        return ranvalue;
    }

}