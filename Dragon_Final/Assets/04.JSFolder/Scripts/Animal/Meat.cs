using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//meat는 처음에 비활성화 되어있다가
//rabbit이 죽으면 meat 오브젝트 활성화
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
