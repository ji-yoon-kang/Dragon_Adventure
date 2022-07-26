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

    // ����
    public GameObject[] prefabs;

    // ���� ���� ��
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
        //print("Spawn����");

        for (int i = 0; i < mushmax; i++) //mushmax �� ��ŭ �����Ѵ�
        {
            //print("Spawn For ����");
            int selection = UnityEngine.Random.Range(0, prefabs.Length);

            GameObject selectedPrefab = prefabs[selection];

            Vector3 spawnPos = Return_RandomPosition();//������ġ�Լ�

            GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            gameObjects.Add(instance);
            instance.transform.parent = this.transform;
            mushCount++;
            //print("Spawn����");
        }
    }

    Vector3 Return_RandomPosition()
    {
        //print("������ ����");
        Vector3 originPosition = rangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;


        return respawnPosition;
    }
}
