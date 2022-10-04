using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //변경할 변수
    public float delay;       // delay는 각 글자마다의 출력되는 간격
    public float Skip_delay; // 한문단이 끝났을때 바로 넘기지 못하게 딜레이를 줌
    public int cnt;
    int prevIndex;

    //타이핑효과 변수
    public string[] fulltext;   // 텍스트의 배열
    public int dialog_cnt;     // Fulltext 갯수 지정
    string currentText;

    //타이핑확인 변수
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


    //모든 텍스트 호출완료시 탈출
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

    //다음버튼함수
    //public void End_Typing()
    //{
    //    if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) == true)
    //        //다음 텍스트 호출
    //        if (text_full == true)
    //        {
    //            // 랜덤으로 텍스트가 나오게 한다.
    //            int randValue = Random.Range(0, cnt);
    //            text_full = false;
    //            text_cut = false;
    //            //StartCoroutine(ShowText(fulltext));

    //            uiText.text = fulltext[randValue];
    //        }
    //        //텍스트 타이핑 생략
    //        else
    //        {
    //            text_cut = true;
    //        }


    //}

    ////텍스트 시작호출
    //public void Get_Typing(int _dialog_cnt, string[] _fullText)
    //{
    //    //재사용을 위한 변수초기화
    //    text_exit = false;
    //    text_full = false;
    //    text_cut = false;
    //    cnt = 0;

    //    //변수 불러오기
    //    dialog_cnt = _dialog_cnt;
    //    fulltext = new string[dialog_cnt];
    //    fulltext = _fullText;

    //    //타이핑 코루틴시작
    //    //StartCoroutine(ShowText(fulltext));
    //}

    //IEnumerator ShowText(string[] _fullText)
    //{
    //    //모든텍스트 종료
    //    if (cnt >= dialog_cnt)
    //    {
    //        text_exit = true;
    //        StopCoroutine("showText");
    //    }
    //    else
    //    {
    //        //기존문구clear
    //        currentText = "";
    //        //타이핑 시작
    //        for (int i = 0; i < _fullText[cnt].Length; i++)
    //        {
    //            //타이핑중도탈출
    //            if (text_cut == true)
    //            {
    //                break;
    //            }
    //            //단어하나씩출력
    //            currentText = _fullText[cnt].Substring(0, i + 1);
    //            this.GetComponent<Text>().text = currentText;
    //            yield return new WaitForSeconds(delay);
    //        }
    //        //탈출시 모든 문자출력
    //        Debug.Log("Typing 종료");
    //        this.GetComponent<Text>().text = _fullText[cnt];
    //        yield return new WaitForSeconds(Skip_delay);

    //        //스킵_지연후 종료
    //        Debug.Log("Enter 대기");
    //        text_full = true;
    //    }
    //}
}
