using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] AudioClips;
    public AudioSource audioSource;
   

    public bool muted;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
     //   instance = this;
        starMode();
   //     AudioControlerCheck();
    }

    private void AudioControlerCheck()
    {
        int music = 0;
        int audio = 0;
        if (AudioControler.instance != null)
        {
            if (PlayerPrefs.HasKey(AudioControler.instance.MusicKey))
            {
                music = PlayerPrefs.GetInt(AudioControler.instance.MusicKey);
                audio = PlayerPrefs.GetInt(AudioControler.instance.SoundKey);
                Debug.Log("music: " + music + ", Sound: " + audio) ;
            }
            else
            {
                Debug.Log("Key not found");
            }
        }
        else
        {
            Debug.Log("Audio controller not found");
        }


        if (music == 0)
        {
            muted = false;
        }
        else
            muted = true;


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

    public void SoundMuteControl()
    {
        if(PlayerPrefs.GetInt("_sound") == 0)
        {

        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("music: " + PlayerPrefs.GetInt(AudioControler.instance.MusicKey) + ", Sound: " +PlayerPrefs.GetInt(AudioControler.instance.SoundKey));
      //  AudioControlerCheck();
        if(PlayerPrefs.GetInt("_music") == 0)
        {
            muted = false;
        }
        else
        {
            muted = true;
        }

    }

    public void PlayAudio(int id)
    {
        if (!muted)
        {
            AudioSource source = GetComponent<AudioSource>();
            if (source != null)
            {
                audioSource.PlayOneShot(AudioClips[id]);
            }
            else
            {
                AudioSource sc = gameObject.AddComponent<AudioSource>() as AudioSource;
                sc.PlayOneShot(AudioClips[id]);
            }

        }
       
    }

   


}
