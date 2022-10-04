using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//1. static으로 설정 후 waypoint 설정
//2. stick collider 에 닿으면 
//3. dead상태로 바뀌면서
//5. 고기가 나옴
//6. B버튼을 누르면 고기 가져오기(인벤토리 완성된후)
//토끼가 앞으로 가면서
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

        //순찰 불러오기
        UpdatePatrol();
    }

    private void UpdateDead()
    {
        OnDeadFinished();
    }

    bool isdeath = false;
    //애니메이션 이벤트 함수
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
        

        //추후 파티클 및 고기 오브젝트
        //gameObject.SetActive(false);    //Invoke로 불러오기
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
    //Trigger를 이용
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Stick") == true)
        {
            state = State.DEAD;
            anim.SetTrigger("Dead");
        }
    }
    bool start = false;
    //웨이포인트
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
