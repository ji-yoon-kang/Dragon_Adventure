using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDeaccelation : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        print(DragonMovement.Instance.isDeAcelL + "L �𿢼�");
        print(DragonMovement.Instance.isDeAcelR + "R �𿢼�");
    }
    protected IEnumerator VibrateController(float waitTime, float frequency, float amplitude, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
    private void OnTriggerStay(Collider other)
    {
        // ���� ��Ʈ�ѷ��� �Ѵ� collision �Ǹ� �巡�� ����
        if (DragonMovement.Instance.isfly == true)
        {
            if (other.gameObject.name.Contains("LeftControllerAnchor"))
            {
                DragonMovement.Instance.isDeAcelL = true;
                StartCoroutine(VibrateController(0.5f, 0.5f, 0.5f, OVRInput.Controller.LTouch));
            }

            if (other.gameObject.name.Contains("RightControllerAnchor"))
            {
                DragonMovement.Instance.isDeAcelR = true;
                StartCoroutine(VibrateController(0.5f, 0.5f, 0.5f, OVRInput.Controller.RTouch));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (DragonMovement.Instance.isfly == true)
        {
            if (other.gameObject.name.Contains("LeftControllerAnchor"))
            {
                DragonMovement.Instance.isDeAcelL = false;
            }

            if (other.gameObject.name.Contains("RightControllerAnchor"))
            {
                DragonMovement.Instance.isDeAcelR = false;
            }
        }
    }
}
