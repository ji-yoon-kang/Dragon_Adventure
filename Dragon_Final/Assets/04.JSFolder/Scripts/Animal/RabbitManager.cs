using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitManager : MonoBehaviour
{
    public static RabbitManager instance;
    private void Awake()
    {
        instance = this;
    }

    //����ð�
    float currentTime;
    //�����ð�
    public float createTime = 2;
    //������
    public GameObject rabbitFactory;

    public int rabbitCount = 0;
    int rabbitLimit = 2;

    


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject selectPrefab = rabbitFactory;

        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            float spawnX = Random.Range(0, 10);
            float spawnZ = Random.Range(0, 10);

            selectPrefab.transform.position = new Vector3(spawnX, 0, spawnZ);
            if(selectPrefab != null)
            {
                if(rabbitCount<rabbitLimit)
                {
                    Instantiate(selectPrefab);
                    rabbitCount++;

                }
            }

            currentTime = 0;
        }

    }
}
