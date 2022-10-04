using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // inspector창에서 수정가능하게 함
public class Sound   // Sound 정보를 담고 있는 클래스
{
    public string name;   // 사운드 이름
    public AudioClip clip;   // 실제 mp3음원을 여기에 넣으면 됨
}

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
      //  PlayBGM();
    }

    [SerializeField] Sound bgm;
    [SerializeField] Sound[] sfx;

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource[] sfxPlayer;

    public void PlayBGM()
    {
        bgmPlayer.Play();
    }

    public void PlaySFX(string p_sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {

                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                    else
                    {
                        print(sfxPlayer[x].clip.name + " is Playing");
                    }
                    print("SfxPlayer[" + x + "] Name : " + sfxPlayer[x].clip.name);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
