using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayerControl : MonoBehaviour
{
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CharControl();
    }

    void CharControl()
    {
        //thumbstick Á¦¾î Axis1d : vector 1(x)  axis2d : vector2(y)
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        //Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        //cc.Move(this.transform.forward * Lpos.y * Time.deltaTime * 1f);
        //this.transform.Translate(this.transform.forward * Lpos.y * Time.deltaTime * 1f);
        this.transform.Rotate(this.transform.up * Rpos.x * Time.deltaTime * 45f, Space.Self);
    }
}
