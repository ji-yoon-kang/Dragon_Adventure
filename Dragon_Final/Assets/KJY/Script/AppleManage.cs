using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManage : MonoBehaviour
{
    // 사과
    GameObject apple;
    // 사과 공장
    public GameObject appleFactory;
    // 사과 공장 위치
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
            //print("부딪힘");

            // 랜덤 값을 받아온다.
            int value = Random.Range(0, 5);
            print(value);
            if (value < 3)
            {
                //print("사과 생성");

                // 사과 공장에서 사과를 만들어서
                apple = Instantiate(appleFactory);
                // 사과 공장의 위치에 배치하고 싶다.
                apple.transform.position = appleFactoryPos.transform.position;
            }
            //print("부딪힘멈춤");
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
