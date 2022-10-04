using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Animator animator;
    public GameObject screenUI;
    public GameObject scenemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("BigDragon"))
        {
            print("¥Í¿Ω");
            DontDestroyOnLoad(scenemanager);
            StartCoroutine("EndingFade");
        }
    }

    IEnumerator EndingFade()
    {
        screenUI.SetActive(true);
        animator.SetTrigger("Fade_Out");
        print("æ÷¥œ");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("Fade_In");
    }
}
