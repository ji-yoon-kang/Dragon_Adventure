using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//1. static���� ���� �� waypoint ����
//2. stick collider �� ������ 
//3. dead���·� �ٲ�鼭
//5. ��Ⱑ ����
//6. B��ư�� ������ ��� ��������(�κ��丮 �ϼ�����)
//�䳢�� ������ ���鼭
//
public class Rabbit : MonoBehaviour
{
    //public static Rabbit instance;

    //private void Awake()
    //{
    //    instance = this;
    //}

    public enum State
    {    
        RUN,
        DEAD,
    }
    public State state = 0;
    public Animator anim;
    public GameObject particle;

   
    
    NavMeshAgent agent = null;
    public int index = 0;
    public int ranvalue;
    Transform[] wayPoints;
    public Vector3 target;

    public GameObject meat;
    bool isMeat;
    

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = new Transform[4];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = GameObject.Find("PathManager").transform.GetChild(i);
            print(wayPoints[i].gameObject.name);
        }
        agent = GetComponent<NavMeshAgent>();


        state = State.RUN;

        particle.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.RUN:
                UpdateRun();
                break;
            case State.DEAD:
                UpdateDead();
                break;
        }
    }

    private void UpdateRun()
    {

        //���� �ҷ�����
        UpdatePatrol();
    }

    private void UpdateDead()
    {
        OnDeadFinished();
    }

    bool isdeath = false;
    //�ִϸ��̼� �̺�Ʈ �Լ�
    void OnDeadFinished()
    {
        if(isdeath == false)
        {
            if (particle != null)
            {
                particle.SetActive(true);
                
                //rabbitCount--;
            }
            RabbitManager.instance.rabbitCount--;
            isdeath = true;
        }
        

        //���� ��ƼŬ �� ��� ������Ʈ
        //gameObject.SetActive(false);    //Invoke�� �ҷ�����
        Invoke("Active", 1.5f);
    }

    void Active()
    {
        if(isMeat != true)
        {
            GameObject meat1 = Instantiate(meat);
            meat1.name = "Meat";
            meat1.transform.position = this.transform.position;
            if(gameObject.activeSelf == true)
            {
            gameObject.SetActive(false);
                print("2");
            }
            isMeat = true;
            
        }
        
    }
    //Trigger�� �̿�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Stick") == true)
        {
            state = State.DEAD;
            anim.SetTrigger("Dead");
        }
    }
    bool start = false;
    //��������Ʈ
    void UpdatePatrol()
    {
        anim.SetTrigger("Run");

        //bool start = false;
        if (!start)
        {
            int ran = SetRanValue();
            agent.SetDestination(wayPoints[ran].transform.position);
            target = wayPoints[ran].transform.position;
            start = true;
        }
        float distance = Vector3.Distance(transform.position, target);

        //print(distance);
        if (distance < 2)
        {
            //print("Change Target");
            int ran = SetRanValue();
            target = wayPoints[ran].position;
            agent.destination = target;
        }
    }

    public int SetRanValue()
    {

        ranvalue = UnityEngine.Random.Range(0, wayPoints.Length);

        return ranvalue;
    }

}
