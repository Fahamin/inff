using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] AudioClips;
    public AudioSource audioSource;
    public AudioClip  Clickbutton ;

    public bool muted;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        starMode();
    }

    private void audioCheck()
    {
        int music = PlayerPrefs.GetInt("music");
        int audio = PlayerPrefs.GetInt("audio");

        if (music == 1)
        {
            muted = false;
        }
        else if (music == 0)
        {
            muted = true;
        }

        if (audio == 1)
        {
            gameObject.SetActive(false);

        }
        if(audio == 0)
        {
            gameObject.SetActive(true);
        }


    }

    void starMode()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        audioSource.GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        audioCheck();
        //JointTranslationLimits2D==Logger''

    }

    public void PlayAudio(int id)
    {
        if (muted)
        {
            audioSource.PlayOneShot(AudioClips[id]);
        }
    }

    public void buttonClick ()
        {

        audioSource.PlayOneShot(Clickbutton);
        }


}
