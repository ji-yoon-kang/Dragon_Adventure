using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{

    public static DragonMovement Instance;
    public bool isfly = false;
    public bool isAcelL = false; 
    public bool isAcelR = false;
    public bool isDeAcelL = false;
    public bool isDeAcelR = false;


    private void Awake()
    {
        Instance = this;
    }
    public Animator anim;
    Rigidbody rb;
    public Collider[] moveCheckCols;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        anim.SetTrigger("Start_Anim_CastSpell");
        //
        moveCheckCols = new Collider[3];
    }
    // Update is called once per frame
    void Update()
    {

        FlyControlDragon();
        

    }

    float rollAmount = 20;
    float pitchAmount = 50;

    //�¿� ȸ�� �� ���� �� ���
    float yawAmount = 200;
    float lerpAmount = 4;
    Vector3 rotateValue;

    bool forwardsoundPlay = false; 
    void FlyControlDragon()
    {
        //******************************Fly***************************************
        if (isfly == true)
        {
            //********************************Forward*********************************

            if (isAcelL && isAcelR)
            {

                if (rb.velocity.z < 40)
                {


                    rb.AddForce(this.transform.forward * 1000f, ForceMode.Acceleration);
                    print("����");
                }
                // transform.Translate(new Vector3(0, 0, 10f * Time.deltaTime));
            }

            //********************************Backward********************************

            if (isDeAcelL && isDeAcelR)
            {

                if (rb.velocity.z > 0)
                {
                    
                    rb.AddForce(-this.transform.forward * 1000f, ForceMode.Acceleration);
                    print("��ž");
                }
            }

            //********************************Rotation********************************
            Vector3 rCtl = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Vector3 lCtl = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            Vector3 rot = lCtl - rCtl;
            print(rot + "rot");

            
            if (rot.y > 0.2f)
            {

                    DragonSoundManager.instance.flysound.clip = DragonSoundManager.instance.soundclips[8];
                    DragonSoundManager.instance.flysound.Play();
                
                print("��ȸ��");
            }
            if (rot.y < -0.2f)
            {

                    DragonSoundManager.instance.flysound.clip = DragonSoundManager.instance.soundclips[8];
                    DragonSoundManager.instance.flysound.Play();
                
                print("��ȸ��");
            }
            float pitchValue = 0;
            float yawValue = rot.y;
            float rollValue = 0;

            //Rotate
            Vector3 lerpVector = new Vector3(pitchValue * pitchAmount, yawValue * yawAmount, -rollValue * rollAmount);
            rotateValue = Vector3.Lerp(rotateValue, lerpVector, lerpAmount * Time.deltaTime);
            transform.Rotate(rotateValue * Time.deltaTime);
            //�¿�ȸ�� �ִϸ��̼�
            anim.SetFloat("x", rot.y * 5f);
            //********************************UP,Down********************************
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
            print(pos);
            if (pos.y > 0)
            {
                rb.AddForce(this.transform.up * 300f, ForceMode.Force);
                print("�ö�");
            }
            if (pos.y < 0)
            {
                print("������");
                rb.AddForce(-this.transform.up * 100f, ForceMode.Force);
            }

            //Up,down �ִϸ��̼�
            anim.SetFloat("y", pos.y);



        }
    }

    //ī�޶� ȸ�� �� �޾ƿͼ� ȸ���ϴ� �ڵ�

    /*
        DragonRide dragonride = this.transform.Find("Ridecol").GetComponent<DragonRide>();
        GameObject cam;

        void DragonMove()
        {   if(cam == null)
            {
                cam = transform.Find("RigPelvis").Find("Player").Find("OVRCameraRig").Find("TrackingSpace").Find("CenterEye.Anchor").gameObject;
            }
            print(cam.name);

            float speed = 10;
            this.transform.localRotation = cam.transform.localRotation;
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        //Pitch: X �ö󰡰� ��������
        //Yaw: Y
        //Roll: Z ��ȸ�� ��ȸ��
    */


    //��Ʈ�ѷ��� ȸ���� �����ؼ� �ִϸ��̼� ���� -> �ִϸ��̼� ���� ȸ���� x, y�� ��Ʈ�ѷ� ȸ�������� �޾ƿͼ� �ٲ� ��
    /*   void flycontrol()
       {
           Vector3 rCtl = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
           Vector3 lCtl = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
           Vector3 rot = rCtl - lCtl;
           Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
           print(pos);
           //anim.SetFloat("x", pos.x);
          // anim.SetFloat("y", pos.y);
       }
   */
}