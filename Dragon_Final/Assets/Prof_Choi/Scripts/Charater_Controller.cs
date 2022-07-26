using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        CharControl();

    }

    void CharControl()
    {
        Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        this.transform.Translate(Vector3.forward * pos.y * Time.deltaTime * 1f);
        this.transform.Rotate(Vector3.up * pos.x * Time.deltaTime * 45f);

/*        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) == true)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 15f, ForceMode.Impulse);
        } // b버튼 점프로직
*/
    }
}
