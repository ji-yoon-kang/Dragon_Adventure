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

    //�����ư�� ������ �����ϴ� ����� ȣ���ϰ�ʹ�
    public void OnClickQuit()
    {
        Application.Quit();
    }
    //����۹�ư�� ������ �����
    public void OnClickStart()
    {
        print("OnClickRestart");
        //����� =  ���� scene�� �ٽ� Load �ϰ�ʹ�
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        //���� �����ִ� Scene�� �����
    }
}
