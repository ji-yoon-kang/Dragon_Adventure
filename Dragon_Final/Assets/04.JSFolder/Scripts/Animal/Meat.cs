using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//meat�� ó���� ��Ȱ��ȭ �Ǿ��ִٰ�
//rabbit�� ������ meat ������Ʈ Ȱ��ȭ
public class Meat : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("cc");
       // if (collision.gameObject.name.Contains("RightControllerAnchor"))
      //  {
            print("dd");
            this.enabled = false;
       // }
    }
}
