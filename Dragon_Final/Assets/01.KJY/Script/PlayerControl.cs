using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    AudioSource walkingSfx;
    CharacterController cc;

    Rigidbody rb;
    public float Trans_speed = 5f;
    public float Rot_speed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        walkingSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        CharControl();
        WalkingSfx();
    }
    void CharControl()
    {
        //thumbstick Á¦¾î Axis1d : vector 1(x)  axis2d : vector2(y)
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

        Vector3 dir = transform.forward;
        dir.y = 0;
        dir = dir.normalized;

        Vector3 totalVelocity = transform.forward * Trans_speed * Rpos.y + transform.right * Trans_speed * Rpos.x + Vector3.up * -9.8f;

        cc.Move(totalVelocity * Time.deltaTime);
        this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 45f, Space.Self);

        //Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        //this.transform.Translate(Vector3.forward * pos.y * Time.deltaTime * Trans_speed);
        //this.transform.Rotate(Vector3.up * pos.x * Time.deltaTime * Rot_speed);
    }

    public void WalkingSfx()
    {
        //print(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch));
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch) == Vector2.zero)
        {
            // if(walkingSfx.isPlaying == false)
            walkingSfx.Stop();
        }
        else
        {
            if (walkingSfx.isPlaying == false)
                walkingSfx.Play();
        }
    }
}