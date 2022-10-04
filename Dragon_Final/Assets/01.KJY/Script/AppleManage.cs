using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManage : MonoBehaviour
{
    // ���
    GameObject apple;
    // ��� ����
    public GameObject appleFactory;
    // ��� ���� ��ġ
    public Transform appleFactoryPos;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    bool makeapple = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") && makeapple ==false)
        {
            //print("�ε���");

            // ���� ���� �޾ƿ´�.
            int value = Random.Range(0, 5);
            print(value);
            if (value < 3)
            {
                //print("��� ����");

                // ��� ���忡�� ����� ����
                apple = Instantiate(appleFactory);
                // ��� ������ ��ġ�� ��ġ�ϰ� �ʹ�.
                apple.transform.position = appleFactoryPos.transform.position;
            }
            //print("�ε�������");
            makeapple = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable")) {
            makeapple = false;
                 }
    }
}
