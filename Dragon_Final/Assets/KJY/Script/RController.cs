using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RController : MonoBehaviour
{
    public GameObject player;
    //�߻�����
    public Transform grabpos;
    GameObject grabobj; //������ ��ü�� ������ �ޱ� ���ؼ�

    public bool isgrab = false; //�������� X
    bool iscontact = false; //������ X

    AudioMgr theAudioManager;

    void Start()
    {
        isgrab = false;
        iscontact = false;
        theAudioManager = AudioMgr.instance;
    }

    //�浹�� ����.. �浹�� ��ü�� ��´�(�� ��ü�� ���Եȴ�)
    private void OnTriggerEnter(Collider other)
    {
        // other.gameObject.tag = "Grabable";
        if (other.CompareTag("Grabable") == true && isgrab == false)
        {
            iscontact = true; // ������ O
            grabobj = other.gameObject;  // ������ ��ü�� ������ grapobject�� �Ѱ���
            if (isgrab == false) //���˵Ǿ����� ª�� ������
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") == true && isgrab == false)
        {
            iscontact = false; // ���� ����
            grabobj = null;  // ������ ��ü�� ������ �ʱ�ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 obj_velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        obj_velocity.Normalize();
        Grabobj(); //1)��´�...2)�����߰�..3)grab ���� 4)������� Ű�Է� -> ��� ���
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
            grabobj.transform.SetParent(grabpos); // ��Ʈ�ѷ����� grabpos�� �θ� ��
            isgrab = true;
            theAudioManager.PlaySFX("Item_Select");
        }
    }
    void Releaseobj()
    {
        // ��ü�� ���´� 1)������ ������ 2) ��ư�� ��������
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
                    // ��Ʈ�ѷ����� grabpos�� null�� ��
                }
            }

            isgrab = false;
            iscontact = false;
            grabobj = null;
        }
    }
}