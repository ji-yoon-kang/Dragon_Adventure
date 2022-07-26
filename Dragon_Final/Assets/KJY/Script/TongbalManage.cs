using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongbalManage : MonoBehaviour
{
    public static TongbalManage instance;
    private void Awake()
    {
        instance = this;
        rangeCollider = rangeObject.GetComponentInChildren<BoxCollider>();
    }

    // 물고기
    public GameObject[] prefabs;

    private List<GameObject> gameObjects = new List<GameObject>();

    public GameObject rangeObject;

    BoxCollider rangeCollider;
    // 버섯 생성 값
    int fishCount = 0;
    int fishMaxCount = 3;
    bool isfishOn = false;

    void Start()
    {
        fishCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isfishOn == false && other.tag == "Water")
        {
            print("바보");
            Invoke("Spawn", 3f);
            //Spawn();
            isfishOn = true;
        }
    }

    private void Spawn()
    {
         print("붕");
            for (int i = 0; i < fishMaxCount; i++) //fishCount 수 만큼 생성한다
            {
                print("방");
                int selection = UnityEngine.Random.Range(0, prefabs.Length);

                GameObject selectedPrefab = prefabs[selection];

                Vector3 spawnPos = Return_RandomPosition();//랜덤위치함수

                GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
                gameObjects.Add(instance);
                instance.transform.parent = this.transform;
                fishCount++;
                print("방구");
            }
    }

    Vector3 Return_RandomPosition()
    {
        print("현민");
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        

        return respawnPosition;
    }

    private void Update()
    {
        //print(fishCount);
    }
}
