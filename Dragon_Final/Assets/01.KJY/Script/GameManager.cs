using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    //종료버튼을 누르면 종료하는 기능을 호출하고싶다
    public void OnClickQuit()
    {
        Application.Quit();
    }
    //재시작버튼을 누르면 재시작
    public void OnClickStart()
    {
        print("OnClickRestart");
        //재시작 =  현재 scene을 다시 Load 하고싶다
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        //현재 열려있는 Scene을 재시작
    }
}
