using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_RController : MonoBehaviour
{
    // �߻���
    public Transform grabpos;
    GameObject grabobj;      // ������ ��ü�� ������ �ޱ� ���ؼ� ���� ����

    bool isgrab = false;     // ���� �� ����
    bool iscontact = false;  // ������ �� ����

    void Start()
    {
        isgrab = false;
        iscontact = false;
    }

  
        // �浹�� ���� �浹�� ��ü�� ��´�(�� ��ü�� ���Եȴ�)
        private void OnTriggerEnter(Collider other)
    {
        
        //if (other.gameObject.tag == "Grabbable")
        if (other.CompareTag("Grabbable") == true && isgrab == false) // if�� ���ǽ��� '== true'�� ��������
        {
            iscontact = true;             // ���˵Ǿ���
            grabobj = other.gameObject;   // ������ ��ü�� ������ grabobj�� �Ѱ���
            if (isgrab == false)          // ���˵Ǿ��� �� ª�� ������
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabbable") == true && isgrab == false)
        {
            iscontact = false;   // ���� ����
            grabobj = null;      // ������ ��ü�� ������ �ʱ�ȭ(������ ��ü�� �������� ������ ������ ���� => null)
        }
    }

    void Update()
    {
        GrabObj();  // ��� �Լ�. 1)���� ����. 2)Grab ����. 3)������� Ű�Է� -> �����߰� ���� ������ �����ε� Ű�Է��� ���� �� ��´�.
        ReleaseObj();
    }

    void GrabObj()
    {
        if (iscontact == true &&
            isgrab == false &&
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
        {
            grabobj.GetComponent<Rigidbody>().isKinematic = true;
            grabobj.transform.SetParent(grabpos);  // ��Ʈ�ѷ����� grabpos �θ� ��
            isgrab = true;
        }
    }

   
    void ReleaseObj()
    {
        // ��ü�� ���´�   1)������ ���� �� 2)��ư�� ��������
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true && isgrab == true)
        {
            // �ӵ� ���͸� ������ �Ѵ�.
            Vector3 obj_velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch); // ������ ��Ʈ�ѷ��� �ֵθ� ���� ���� �ӵ���

            grabobj.GetComponent<Rigidbody>().velocity = obj_velocity * 2.3f;
            grabobj.GetComponent<Rigidbody>().isKinematic = false;  // isKinematic = true�� ������ Ȱ��ȭ��Ų�ٴ� �ǹ�

            // ���� ������ �ִ� ���� �θ� ����. �� �����̴�.
            grabobj.transform.SetParent(null);

            // �����͵� �����Ѱ͵� ����.
            isgrab = false;
            iscontact = false;

            // ���� ��ü�� ������ ������.
            grabobj = null;
        }
    }
}