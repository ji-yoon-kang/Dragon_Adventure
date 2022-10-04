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
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, Mathf.Infinity) == true) //광선을 쏘고
        {
            // 라인 렌더 길이 조정
            ln.SetPosition(1, new Vector3(0, 0, hit.distance));
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true) //키입력을 받아
            {
                if (hit.transform.tag == "UI") //부딪힌게 UI라면
                {
                    switch (hit.transform.name)
                    {
                        case "Start_Button":
                            // hit.point 맞은 위치에 파티클
                            OnClickStart();
                            break;

                        case "Quit_Button":
                            // hit.point 맞은 위치에 파티클
                            OnClickQuit();
                            break;

                        case "Skip_Button":
                            // hit.point 맞은 위치에 파티클
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

    //종료버튼을 누르면 종료하는 기능을 호출하고싶다
    public void OnClickQuit()
    {
        Application.Quit();
    }
/*    private void OnTriggerEnter(Collider other)
    {
        if (hit.transform.tag == "UI") //부딪힌게 UI라면
        {
            switch (other.gameObject.name)
            {
                case "OK":
                    // hit.point 맞은 위치에 파티클
                    //inputtxt.text = "working";
                    break;
            }
        }
    }*/
}
