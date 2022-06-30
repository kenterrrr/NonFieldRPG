using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AudioSource audioSourceBGM; // SE�̃X�s�[�J�[
    public AudioClip[] audioClipBGM; // �炷�f��
    public const string TITLE = "Title";
    public const string TOWN = "Town";
    public const string QUEST = "Quest";
    public const string BATTLE = "Battle";

    public AudioSource audioSourceSE; // SE�̃X�s�[�J�[
    public AudioClip[] audioClipSE; // �炷�f��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayBGM(string sceneName)
    {
        switch (sceneName)
        {
            case TITLE:
                audioSourceBGM.clip = audioClipBGM[0];
                break;

            case TOWN:
                audioSourceBGM.clip = audioClipBGM[1];
                break;

            case QUEST:
                audioSourceBGM.clip = audioClipBGM[2];
                break;

            case BATTLE:
                audioSourceBGM.clip = audioClipBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipSE[index]); // SE����x�����Ȃ炷
    }
}
