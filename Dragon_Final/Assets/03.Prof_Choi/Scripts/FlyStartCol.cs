using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyStartCol : MonoBehaviour
{
    Vector3 LCtrlVeclocity;
    Vector3 RCtrlVeclocity;

    bool fly;
    AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LCtrlVeclocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
        RCtrlVeclocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        //print(LCtrlVeclocity);
        //print(RCtrlVeclocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        //&& other.transform.gameObject.name.Contains("")
        if ((LCtrlVeclocity.y < -0.5f && RCtrlVeclocity.y < -0.5f) && fly == false)
        {

            // 날아오르는 사운드 넣기
            if (DragonMovement.Instance.isfly == false)
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
                bgm.enabled = true;
                bgm.Play();
                DragonMovement.Instance.isfly = true;
                DragonSoundManager.instance.flysound.clip = DragonSoundManager.instance.soundclips[9];
                DragonSoundManager.instance.flysound.Play();

            }
            DragonMovement.Instance.anim.SetBool("Fly Idle", true);
            fly = true;
        }

    }
}
