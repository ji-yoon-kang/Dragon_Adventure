using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittleDragon : MonoBehaviour
{
    /* To-do List */
    // 움직임(?)

    /* 먹이 오브젝트 */
    public GameObject mushroom;
    public GameObject apple;
    public GameObject fish;
    public GameObject meat;
    public GameObject herb;

    /* 호감도 */
    LittleDragonLV dlv;

    /* 오디오 매니저 */
    AudioMgr theAudioManager;


    /* 표정 */
    GameObject face;
    SkinnedMeshRenderer smr;
    Material[] facemat = new Material[3];

    /* 먹이주기 변수 */
    int foodCount;
    int foodMaxCount = 3;

    /* 대화 변수 */
    int chatCount;
    int chatMaxCount = 3;
    public GameObject bigDragon;
    void Start()
    {
        foodCount = 0;
        chatCount = 0;
        face = this.transform.Find("DragonSD_18").Find("Face").gameObject;
        smr = face.GetComponent<SkinnedMeshRenderer>();
        facemat[0] = Resources.Load<Material>("Dino_Face/Dino_Face07");
        facemat[1] = Resources.Load<Material>("Dino_Face/Dino_Face03");
        facemat[2] = Resources.Load<Material>("Dino_Face/Dino_Face19");
        // Resources폴더 > Dino_Face폴더 > Dino_Face01 Material찾을 때 이렇게 씀. 단 Resources폴더에서 자료찾을때만 'Resources.Load<>' 이렇게 씀
        //print(facemat[0].name);

        dlv = GetComponent<LittleDragonLV>();
        LittleDragonLV.instance.dlvUI.SetActive(false);
        DialogueManager.instance.dialogueUI.SetActive(false);
        theAudioManager = AudioMgr.instance;

        /*
                // map에 미리 넣어 놓고 좌표값만 변경하는 방법
                if (GameObject.Find("BigDragon") != null)  -> 처음부터 null인지 아닌지 체크하는 것보다는, 유니티에서 실행했을 때 오류가 나면 if조건문 안에 null인지 아닌지 검사하는 것이 좋다.
                {
                    GameObject bd = GameObject.Find("BigDragon");
                    bd.transform.position = this.transform.position;
                    bd.transform.rotation = this.transform.rotation;
                }

                //public GameObject로 Prefab 받아와서 Instantiate 하는 방법
                //유니티 창에서 직접 prefab 넣어주기
                GameObject bd1 = Instantiate(bigDragon);
                bd1.transform.position = this.transform.position;
                bd1.transform.rotation = this.transform.rotation;


                //Resources 폴더에서 프리펩 읽어와서 Instantiate 하는 방법
                GameObject dragon = Resources.Load<GameObject>("BigDragon");
                GameObject dra = Instantiate(dragon);
                dra.transform.position = this.transform.position;
                dra.transform.rotation = this.transform.rotation;
        */
    }
    GameObject bd;
    GameObject dragon;
    // Update is called once per frame
    void Update()
    {
        Upgrade();

    }

    // 대화하기
    void Chat()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch) == true)
        {

            StartCoroutine(IEChat());
            dlv.LV = dlv.LV + 1;
            chatCount++;
            theAudioManager.PlaySFX("LittleDragon_Chat");

        }
    }

    // 쓰담쓰담
    private void OnTriggerEnter(Collider other)
    {

    }
    bool issd = false; // triggerStay일 때 한번만 쓰다듬게 하는 bool값
    private void OnTriggerStay(Collider other)
    {
        float LtouchrightVel = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).x;
        if (other.gameObject.name.Contains("LeftControllerAnchor") && (LtouchrightVel > 2 || LtouchrightVel < -2) && issd == false)
        {
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            dlv.LV = dlv.LV + 1;
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Pat");
            //print("작동됨");
            issd = true;
        }

        if (other.gameObject.name.Contains("RightControllerAnchor"))
        {
            Chat();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        issd = false;

    }


    // 먹이주기
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Mushroom"))
        {
            // 나의 호감도를 1 올리고
            dlv.LV = dlv.LV + 1;
            // 나의 기분이 좋아졌다가 다시 기본 표정으로 돌아간다.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Apple"))
        {
            // 나의 호감도를 2 올리고
            dlv.LV = dlv.LV + 2;
            // 나의 기분이 좋아졌다가 다시 기본 표정으로 돌아간다.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Fish"))
        {
            // 나의 호감도를 3 올리고
            dlv.LV = dlv.LV + 3;
            // 나의 기분이 좋아졌다가 다시 기본 표정으로 돌아간다.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Meat"))
        {
            // 나의 호감도를 4 올리고
            dlv.LV = dlv.LV + 4;
            // 나의 기분이 좋아졌다가 다시 기본 표정으로 돌아간다.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Herb"))
        {
            // 나의 호감도를 5 올리고
            dlv.LV = dlv.LV + 5;
            // 나의 기분이 좋아졌다가 다시 기본 표정으로 돌아간다.
            StartCoroutine(IEHappy());
            theAudioManager.PlaySFX("LittleDragon_Healing");
            Destroy(collision.gameObject);
            foodCount++;
        }
    }

    // 표정변화
    IEnumerator IEChangeFace()
    {
        LittleDragonLV.instance.dlvUI.SetActive(true);
        smr.material = facemat[1];
        yield return new WaitForSeconds(0.7f);
        LittleDragonLV.instance.dlvUI.SetActive(false);
        yield return new WaitForSeconds(2);
        smr.material = facemat[0];
    }

    // 힐링하기
    IEnumerator IEHappy()
    {
        LittleDragonLV.instance.dlvUI.SetActive(true);
        smr.material = facemat[2];
        yield return new WaitForSeconds(0.7f);
        LittleDragonLV.instance.dlvUI.SetActive(false);
        yield return new WaitForSeconds(3);
        smr.material = facemat[0];
    }

    IEnumerator IEChat()
    {
        DialogueManager.instance.dialogueUI.SetActive(true);
        DialogueManager.instance.Typing_RanTxt();
        LittleDragonLV.instance.dlvUI.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        LittleDragonLV.instance.dlvUI.SetActive(false);
        yield return new WaitForSeconds(1.3f);
        DialogueManager.instance.dialogueUI.SetActive(false);
    }

    //public GameObject fadeControl;
    //public Image fadeInOut_Img;
    public Animator animator;
    public GameObject change_particle;

    void Upgrade()
    {
        //&& foodCount >= foodMaxCount && chatCount >= chatMaxCount
        // 호감도가 full로 채워지고, 먹이주기 3번/대화 3번 하는 조건 모두 충족하면
        if (dlv.LV >= LittleDragonLV.instance.maxLV)
        //if (dlv.LV >= LittleDragonLV.instance.maxLV)
        {
            print("aa");
            //start에서 Find하지 않을 때는 반드시 null검사를 하고 찾아와야 한다.


            // 어른용으로 변신한다.
            //새끼용 파티클 하고 3초후에 화면 하얗게 만들고
            //용 바꿔치기
            //다시 화면 원래대로

            StartCoroutine(Wait());

        }
    }
    bool a = false;
    IEnumerator Wait()
    {

        change_particle.SetActive(true);
        theAudioManager.PlaySFX("Transformation");
        yield return new WaitForSeconds(2);
        animator.SetTrigger("Fade_Out");
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
        if (a == false)
        {
            bd = Resources.Load<GameObject>("BigDragon");
            dragon = Instantiate(bd);
            dragon.transform.position = this.transform.position;
            dragon.transform.rotation = this.transform.rotation;
            a = true;
        }
        animator.SetTrigger("Fade_In");

    }

}
