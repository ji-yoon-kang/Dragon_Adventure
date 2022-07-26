using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Action : MonoBehaviour
{
    RaycastHit hit;
    public LineRenderer ln;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, Mathf.Infinity) == true) //������ ���
        {
            // ���� ���� ���� ����
            ln.SetPosition(1, new Vector3(0, 0, hit.distance));
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true) //Ű�Է��� �޾�
            {
                if (hit.transform.tag == "UI") //�ε����� UI���
                {
                    switch (hit.transform.name)
                    {
                        case "Start_Button":
                            // hit.point ���� ��ġ�� ��ƼŬ
                            OnClickStart();
                            break;

                        case "Quit_Button":
                            // hit.point ���� ��ġ�� ��ƼŬ
                            OnClickQuit();
                            break;

                        case "Skip_Button":
                            // hit.point ���� ��ġ�� ��ƼŬ
                            OnClickSkip();
                            break;

                    }
                }
            }
        }
    }
    public void OnClickStart()
    {
        print("OnClickStart");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnClickSkip()
    {
        print("OnClickSkip");
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    //�����ư�� ������ �����ϴ� ����� ȣ���ϰ�ʹ�
    public void OnClickQuit()
    {
        Application.Quit();
    }
/*    private void OnTriggerEnter(Collider other)
    {
        if (hit.transform.tag == "UI") //�ε����� UI���
        {
            switch (other.gameObject.name)
            {
                case "OK":
                    // hit.point ���� ��ġ�� ��ƼŬ
                    //inputtxt.text = "working";
                    break;
            }
        }
    }*/
}
