using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//**1 Player 이동 관련 스크립트 다 꺼줘야 함 
public class DragonRide : MonoBehaviour
{
    public bool ride = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        //타기
        if (other.gameObject.name.Contains("Player"))
        {
            float secondaryTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            if (secondaryTrigger >= 0.95f)
            {
                ride = true;
                
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                //**1
                if (other.gameObject.GetComponent<CharacterController>().enabled == true)
                {
                    other.gameObject.GetComponent<CharacterController>().enabled = false;
                }
                if (other.gameObject.GetComponent<PlayerControl>().enabled == true)
                {
                    other.gameObject.GetComponent<PlayerControl>().enabled = false;
                }
                if (other.gameObject.GetComponent<CapsuleCollider>().enabled == true)
                {
                    other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                }

                other.gameObject.transform.position = this.transform.position+ new Vector3(0,0.7f,0);
                //탔을 때 앞 바라보기 구현 -> 불가능하다고 하셨음
                // 탔을 때 UI로 날아오르려면 양쪽 컨트롤러로 드래곤을 강하게 터치해달라고 하기
                other.transform.SetParent(this.transform.parent.Find("RigPelvis"));
                


            }
        }
        //내리기
        
    }
}
