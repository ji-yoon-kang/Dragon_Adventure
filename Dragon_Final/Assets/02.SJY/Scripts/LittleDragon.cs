using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittleDragon : MonoBehaviour
{
    /* To-do List */
    // ������(?)

    /* ���� ������Ʈ */
    public GameObject mushroom;
    public GameObject apple;
    public GameObject fish;
    public GameObject meat;
    public GameObject herb;

    /* ȣ���� */
    LittleDragonLV dlv;

    /* ����� �Ŵ��� */
    AudioMgr theAudioManager;


    /* ǥ�� */
    GameObject face;
    SkinnedMeshRenderer smr;
    Material[] facemat = new Material[3];

    /* �����ֱ� ���� */
    int foodCount;
    int foodMaxCount = 3;

    /* ��ȭ ���� */
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
        // Resources���� > Dino_Face���� > Dino_Face01 Materialã�� �� �̷��� ��. �� Resources�������� �ڷ�ã������ 'Resources.Load<>' �̷��� ��
        //print(facemat[0].name);

        dlv = GetComponent<LittleDragonLV>();
        LittleDragonLV.instance.dlvUI.SetActive(false);
        DialogueManager.instance.dialogueUI.SetActive(false);
        theAudioManager = AudioMgr.instance;

        /*
                // map�� �̸� �־� ���� ��ǥ���� �����ϴ� ���
                if (GameObject.Find("BigDragon") != null)  -> ó������ null���� �ƴ��� üũ�ϴ� �ͺ��ٴ�, ����Ƽ���� �������� �� ������ ���� if���ǹ� �ȿ� null���� �ƴ��� �˻��ϴ� ���� ����.
                {
                    GameObject bd = GameObject.Find("BigDragon");
                    bd.transform.position = this.transform.position;
                    bd.transform.rotation = this.transform.rotation;
                }

                //public GameObject�� Prefab �޾ƿͼ� Instantiate �ϴ� ���
                //����Ƽ â���� ���� prefab �־��ֱ�
                GameObject bd1 = Instantiate(bigDragon);
                bd1.transform.position = this.transform.position;
                bd1.transform.rotation = this.transform.rotation;


                //Resources �������� ������ �о�ͼ� Instantiate �ϴ� ���
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

    // ��ȭ�ϱ�
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

    // ���㾲��
    private void OnTriggerEnter(Collider other)
    {

    }
    bool issd = false; // triggerStay�� �� �ѹ��� ���ٵ�� �ϴ� bool��
    private void OnTriggerStay(Collider other)
    {
        float LtouchrightVel = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).x;
        if (other.gameObject.name.Contains("LeftControllerAnchor") && (LtouchrightVel > 2 || LtouchrightVel < -2) && issd == false)
        {
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
            dlv.LV = dlv.LV + 1;
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Pat");
            //print("�۵���");
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


    // �����ֱ�
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Mushroom"))
        {
            // ���� ȣ������ 1 �ø���
            dlv.LV = dlv.LV + 1;
            // ���� ����� �������ٰ� �ٽ� �⺻ ǥ������ ���ư���.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Apple"))
        {
            // ���� ȣ������ 2 �ø���
            dlv.LV = dlv.LV + 2;
            // ���� ����� �������ٰ� �ٽ� �⺻ ǥ������ ���ư���.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Fish"))
        {
            // ���� ȣ������ 3 �ø���
            dlv.LV = dlv.LV + 3;
            // ���� ����� �������ٰ� �ٽ� �⺻ ǥ������ ���ư���.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Meat"))
        {
            // ���� ȣ������ 4 �ø���
            dlv.LV = dlv.LV + 4;
            // ���� ����� �������ٰ� �ٽ� �⺻ ǥ������ ���ư���.
            StartCoroutine(IEChangeFace());
            theAudioManager.PlaySFX("LittleDragon_Eat");
            Destroy(collision.gameObject);
            foodCount++;
        }
        if (collision.gameObject.name.Contains("Herb"))
        {
            // ���� ȣ������ 5 �ø���
            dlv.LV = dlv.LV + 5;
            // ���� ����� �������ٰ� �ٽ� �⺻ ǥ������ ���ư���.
            StartCoroutine(IEHappy());
            theAudioManager.PlaySFX("LittleDragon_Healing");
            Destroy(collision.gameObject);
            foodCount++;
        }
    }

    // ǥ����ȭ
    IEnumerator IEChangeFace()
    {
        LittleDragonLV.instance.dlvUI.SetActive(true);
        smr.material = facemat[1];
        yield return new WaitForSeconds(0.7f);
        LittleDragonLV.instance.dlvUI.SetActive(false);
        yield return new WaitForSeconds(2);
        smr.material = facemat[0];
    }

    // �����ϱ�
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
        // ȣ������ full�� ä������, �����ֱ� 3��/��ȭ 3�� �ϴ� ���� ��� �����ϸ�
        if (dlv.LV >= LittleDragonLV.instance.maxLV)
        //if (dlv.LV >= LittleDragonLV.instance.maxLV)
        {
            print("aa");
            //start���� Find���� ���� ���� �ݵ�� null�˻縦 �ϰ� ã�ƿ;� �Ѵ�.


            // ������� �����Ѵ�.
            //������ ��ƼŬ �ϰ� 3���Ŀ� ȭ�� �Ͼ�� �����
            //�� �ٲ�ġ��
            //�ٽ� ȭ�� �������

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
