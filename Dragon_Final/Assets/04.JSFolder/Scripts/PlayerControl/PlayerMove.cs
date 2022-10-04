using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player 전후좌우로 움직이게 하고 싶다.
//speed는 5
//Axis2D.PrimaryThumbstickButton.PrimaryThumbstick
//
public class PlayerMove : MonoBehaviour
{
    public float Trans_speed = 5f;
    public float Rot_speed = 45f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        this.transform.Translate(Vector3.forward * pos.y * Time.deltaTime * Trans_speed);
        this.transform.Rotate(Vector3.up * pos.x * Time.deltaTime * Rot_speed);
    }

}
