using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // inspectorâ���� ���������ϰ� ��
public class Sound   // Sound ������ ��� �ִ� Ŭ����
{
    public string name;   // ���� �̸�
    public AudioClip clip;   // ���� mp3������ ���⿡ ������ ��
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
