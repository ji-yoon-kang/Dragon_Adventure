using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjManageer : MonoBehaviour
{
    Rabbit rabbit;
    //public GameObject Rabbit;
    public GameObject meat;
    //public Transform Rabbit_Transform;
    // Start is called before the first frame update
    void Start()
    {
        meat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Rabbit_Transform = gameObject.transform.GetComponentInChildren<Transform>();
        //if (Rabbit == null)
        //{
        //    meat.SetActive(true);
        //}
        
    }
}
