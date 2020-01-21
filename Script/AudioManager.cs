using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public bool audioMuted;


    public static AudioManager instance;

    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SoundMuteControl(PlayerPrefs.GetInt("_sound"));
    }

    public void PlayAudio(int id)
    {
        if (!audioMuted)
        {
            AudioSource _sc = GetComponent<AudioSource>();
            if (_sc.enabled)
            {
                _sc.PlayOneShot(audioClips[id]);
            }
            else
            {

                GameObject mainCam = GameObject.Find("Main Camera");

                AudioSource _newsc = mainCam.gameObject.GetComponent<AudioSource>();
                Debug.Log("Id: " + id);
                _newsc.PlayOneShot(audioClips[id]);
            }

            Debug.Log("");
        }
    }
    

    private void Update()
    {
        if(PlayerPrefs.GetInt("_music") == 0)
        {
            audioMuted = false;
        }
        else
        {
            audioMuted = true;
        }
    }

    public void SoundMuteControl(int id)
    {
        AudioSource sc = GetComponent<AudioSource>();
        if (id == 0)
        {
            sc.enabled = false;
        }
        else
        {
            sc.enabled = true;
        }
        Debug.Log("scource: " + id);
    }
}
