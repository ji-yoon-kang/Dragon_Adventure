using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAccelation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        print(DragonMovement.Instance.isAcelL + "L ����");
        print(DragonMovement.Instance.isAcelR + "R ����");
    }
    protected IEnumerator VibrateController(float waitTime, float frequency, float amplitude, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);

    }
    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name + "Colname");
        // ���� ��Ʈ�ѷ��� �Ѵ� collision �Ǹ� �巡�� ����
        if (DragonMovement.Instance.isfly == true)
        {
            if (other.gameObject.name.Contains("LeftControllerAnchor"))
            {
                DragonMovement.Instance.isAcelL = true;
                StartCoroutine(VibrateController(0.1f, 0.3f, 0.2f, OVRInput.Controller.LTouch));
            }
            if (other.gameObject.name.Contains("RightControllerAnchor"))
            {
                DragonMovement.Instance.isAcelR = true;
                StartCoroutine(VibrateController(0.1f, 0.3f, 0.2f, OVRInput.Controller.RTouch));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
/*
        if (DragonMovement.Instance.isfly == true)
        {
            if (other.gameObject.name.Contains("LeftControllerAnchor"))
            {
                DragonMovement.Instance.isAcelL = false;
            }

            if (other.gameObject.name.Contains("RightControllerAnchor"))
            {
                DragonMovement.Instance.isAcelR = false;
            }
        }
*/
    }
}
