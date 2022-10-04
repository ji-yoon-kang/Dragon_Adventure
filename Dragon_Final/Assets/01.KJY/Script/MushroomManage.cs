using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManage : MonoBehaviour
{
    public static MushroomManage  instance;
    private void Awake()
    {
        instance = this;
        rangeCollider = rangeObject.GetComponentInChildren<BoxCollider>();
    }

    // 버섯
    public GameObject[] prefabs;

    // 버섯 생성 값
    int mushCount = 0;
    public int mushmax = 3;
    bool isfishOn = false;

    private List<GameObject> gameObjects = new List<GameObject>();

    public GameObject rangeObject;

    BoxCollider rangeCollider;


    void Start()
    {
        mushCount = 0;
        if (isfishOn == false && mushCount < mushmax)
        {
            Spawn();
            isfishOn = true;
        }
    }

    private void Spawn()
    {
        //print("Spawn들어옴");

        for (int i = 0; i < mushmax; i++) //mushmax 수 만큼 생성한다
        {
            //print("Spawn For 들어엄");
            int selection = UnityEngine.Random.Range(0, prefabs.Length);

            GameObject selectedPrefab = prefabs[selection];

            Vector3 spawnPos = Return_RandomPosition();//랜덤위치함수

            GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            gameObjects.Add(instance);
            instance.transform.parent = this.transform;
            mushCount++;
            //print("Spawn나옴");
        }
    }

    Vector3 Return_RandomPosition()
    {
        //print("포지션 들어옴");
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
}
