using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RController : MonoBehaviour
{
    public GameObject player;
    //발사지점
    public Transform grabpos;
    GameObject grabobj; //접촉한 객체의 정보를 받기 위해서

    public bool isgrab = false; //잡힌적도 X
    bool iscontact = false; //접촉이 X

    AudioMgr theAudioManager;

    void Start()
    {
        isgrab = false;
        iscontact = false;
        theAudioManager = AudioMgr.instance;
    }

    //충돌이 나면.. 충돌난 객체를 잡는다(내 객체에 편입된다)
    private void OnTriggerEnter(Collider other)
    {
        // other.gameObject.tag = "Grabable";
        if (other.CompareTag("Grabable") == true && isgrab == false)
        {
            iscontact = true; // 접촉이 O
            grabobj = other.gameObject;  // 접촉한 객체의 정보를 grapobject에 넘겨줌
            if (isgrab == false) //접촉되었을때 짧게 진동옴
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") == true && isgrab == false)
        {
            iscontact = false; // 접촉 해지
            grabobj = null;  // 접촉한 객체의 정보를 초기화
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 obj_velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        obj_velocity.Normalize();
        Grabobj(); //1)잡는다...2)접촉했고..3)grab 여부 4)잡기위한 키입력 -> 잡는 기능
        Releaseobj();
        /*Inventoryobj();*/
    }
    void Grabobj()
    {
        if (iscontact == true && isgrab == false
            && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,
            OVRInput.Controller.RTouch) == true)
        {

            if (grabobj.GetComponent<Item>() != null && !grabobj.name.Contains("Dragon"))
            {
                if (grabobj.GetComponent<Item>().inSlot == true)
                {
                    grabobj.GetComponent<Item>().inSlot = false;
                }
            }

            grabobj.GetComponent<Rigidbody>().isKinematic = true;
            grabobj.transform.SetParent(grabpos); // 콘트롤러내의 grabpos가 부모가 됨
            isgrab = true;
            theAudioManager.PlaySFX("Item_Select");
        }
    }
    void Releaseobj()
    {
        // 객체를 놓는다 1)잡은게 있을때 2) 버튼을 떼었을때
        if (isgrab == true
            && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger,
            OVRInput.Controller.RTouch) == true)
        {
            if (grabobj.GetComponent<Item>() != null)
            {
                if (grabobj.GetComponent<Item>().inSlot != true)
                {
                    //OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch)
                    Vector3 obj_velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                    grabobj.transform.LookAt(player.transform.position);
                    grabobj.GetComponent<Rigidbody>().isKinematic = false;
                    grabobj.GetComponent<Rigidbody>().velocity = -grabobj.transform.forward * obj_velocity.z * 12f;// + Vector3.up * 1f;

                    grabobj.transform.SetParent(null);
                    // 콘트롤러내의 grabpos가 null이 됨
                }
            }

            isgrab = false;
            iscontact = false;
            grabobj = null;
        }
    }
}