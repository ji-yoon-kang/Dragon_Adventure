using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //������ ����
    public float delay;       // delay�� �� ���ڸ����� ��µǴ� ����
    public float Skip_delay; // �ѹ����� �������� �ٷ� �ѱ��� ���ϰ� �����̸� ��
    public int cnt;
    int prevIndex;

    //Ÿ����ȿ�� ����
    public string[] fulltext;   // �ؽ�Ʈ�� �迭
    public int dialog_cnt;     // Fulltext ���� ����
    string currentText;

    //Ÿ����Ȯ�� ����
    public bool text_exit;
    public bool text_full;
    public bool text_cut;

    public Text uiText;
    public GameObject dialogueUI;

    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Get_Typing(dialog_cnt, fulltext);
        cnt = fulltext.Length;
    }


    //��� �ؽ�Ʈ ȣ��Ϸ�� Ż��
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    int randValue = Random.Range(0, cnt);
        //    uiText.text = fulltext[randValue];
        //}


        //if (text_exit == true)
        //{
        //    gameObject.SetActive(false);
        //}

        Typing_RanTxt();
    }

    public void Typing_RanTxt()
    {
        /* if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) == true)
        {
            int randValue = Random.Range(0, cnt);
            uiText.text = fulltext[randValue];
        }*/

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) == true)
        {
            int temp = 0;
            int index = Random.Range(0, cnt);
            if (prevIndex == index)
            {
                index = (index + 1) % cnt;
            }
            prevIndex = index;

            uiText.text = fulltext[index];

            print(index);
        }
    }

    //������ư�Լ�
    //public void End_Typing()
    //{
    //    if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) == true)
    //        //���� �ؽ�Ʈ ȣ��
    //        if (text_full == true)
    //        {
    //            // �������� �ؽ�Ʈ�� ������ �Ѵ�.
    //            int randValue = Random.Range(0, cnt);
    //            text_full = false;
    //            text_cut = false;
    //            //StartCoroutine(ShowText(fulltext));

    //            uiText.text = fulltext[randValue];
    //        }
    //        //�ؽ�Ʈ Ÿ���� ����
    //        else
    //        {
    //            text_cut = true;
    //        }


    //}

    ////�ؽ�Ʈ ����ȣ��
    //public void Get_Typing(int _dialog_cnt, string[] _fullText)
    //{
    //    //������ ���� �����ʱ�ȭ
    //    text_exit = false;
    //    text_full = false;
    //    text_cut = false;
    //    cnt = 0;

    //    //���� �ҷ�����
    //    dialog_cnt = _dialog_cnt;
    //    fulltext = new string[dialog_cnt];
    //    fulltext = _fullText;

    //    //Ÿ���� �ڷ�ƾ����
    //    //StartCoroutine(ShowText(fulltext));
    //}

    //IEnumerator ShowText(string[] _fullText)
    //{
    //    //����ؽ�Ʈ ����
    //    if (cnt >= dialog_cnt)
    //    {
    //        text_exit = true;
    //        StopCoroutine("showText");
    //    }
    //    else
    //    {
    //        //��������clear
    //        currentText = "";
    //        //Ÿ���� ����
    //        for (int i = 0; i < _fullText[cnt].Length; i++)
    //        {
    //            //Ÿ�����ߵ�Ż��
    //            if (text_cut == true)
    //            {
    //                break;
    //            }
    //            //�ܾ��ϳ������
    //            currentText = _fullText[cnt].Substring(0, i + 1);
    //            this.GetComponent<Text>().text = currentText;
    //            yield return new WaitForSeconds(delay);
    //        }
    //        //Ż��� ��� �������
    //        Debug.Log("Typing ����");
    //        this.GetComponent<Text>().text = _fullText[cnt];
    //        yield return new WaitForSeconds(Skip_delay);

    //        //��ŵ_������ ����
    //        Debug.Log("Enter ���");
    //        text_full = true;
    //    }
    //}
}
