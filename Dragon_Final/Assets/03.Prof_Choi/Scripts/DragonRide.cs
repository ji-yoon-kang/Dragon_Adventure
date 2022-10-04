using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//**1 Player �̵� ���� ��ũ��Ʈ �� ����� �� 
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
        //Ÿ��
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
                //���� �� �� �ٶ󺸱� ���� -> �Ұ����ϴٰ� �ϼ���
                // ���� �� UI�� ���ƿ������� ���� ��Ʈ�ѷ��� �巡���� ���ϰ� ��ġ�ش޶�� �ϱ�
                other.transform.SetParent(this.transform.parent.Find("RigPelvis"));
                


            }
        }
        //������
        
    }
}
