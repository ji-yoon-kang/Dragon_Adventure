using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_RController : MonoBehaviour
{
    // 발사점
    public Transform grabpos;
    GameObject grabobj;      // 접촉한 객체의 정보를 받기 위해서 변수 선언

    bool isgrab = false;     // 잡힌 적 없음
    bool iscontact = false;  // 접촉한 적 없음

    void Start()
    {
        isgrab = false;
        iscontact = false;
    }

  
        // 충돌이 나면 충돌난 객체를 잡는다(내 객체에 편입된다)
        private void OnTriggerEnter(Collider other)
    {
        
        //if (other.gameObject.tag == "Grabbable")
        if (other.CompareTag("Grabbable") == true && isgrab == false) // if문 조건식의 '== true'는 생략가능
        {
            iscontact = true;             // 접촉되었음
            grabobj = other.gameObject;   // 접촉한 객체의 정보를 grabobj에 넘겨줌
            if (isgrab == false)          // 접촉되었을 때 짧게 진동함
            {
                OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            }
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabbable") == true && isgrab == false)
        {
            iscontact = false;   // 접촉 해지
            grabobj = null;      // 접촉한 객체의 정보를 초기화(접촉한 객체와 떨어졌기 때문에 정보가 없음 => null)
        }
    }

    void Update()
    {
        GrabObj();  // 잡는 함수. 1)접촉 여부. 2)Grab 여부. 3)잡기위한 키입력 -> 접촉했고 아직 안잡은 상태인데 키입력을 했을 때 잡는다.
        ReleaseObj();
    }

    void GrabObj()
    {
        if (iscontact == true &&
            isgrab == false &&
            OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
        {
            grabobj.GetComponent<Rigidbody>().isKinematic = true;
            grabobj.transform.SetParent(grabpos);  // 콘트롤러내의 grabpos 부모가 됨
            isgrab = true;
        }
    }

   
    void ReleaseObj()
    {
        // 객체를 놓는다   1)잡은게 있을 때 2)버튼을 떼었을때
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true && isgrab == true)
        {
            // 속도 벡터를 만들어야 한다.
            Vector3 obj_velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch); // 오른쪽 컨트롤러를 휘두를 때에 대한 속도값

            grabobj.GetComponent<Rigidbody>().velocity = obj_velocity * 2.3f;
            grabobj.GetComponent<Rigidbody>().isKinematic = false;  // isKinematic = true는 물리력 활성화시킨다는 의미

            // 내가 가지고 있는 것의 부모가 없다. 즉 남남이다.
            grabobj.transform.SetParent(null);

            // 잡은것도 접촉한것도 없다.
            isgrab = false;
            iscontact = false;

            // 잡은 객체의 정보를 버린다.
            grabobj = null;
        }
    }
}