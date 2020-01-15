using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] AudioClips ;
    public AudioSource audioSource;

    
   
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(this);
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //JointTranslationLimits2D==Logger''
        
    }

    public void PlayAudio(int id)
    {
        audioSource.PlayOneShot(AudioClips[id]);
    }


    public void Enemydestroy()
    {
        audioSource.PlayOneShot(AudioClips[3]);
    }

    public void PlayerJump()
    {
        audioSource.PlayOneShot(AudioClips[1]);
    }
    public void PlayerCrouch()
    {
        audioSource.PlayOneShot(AudioClips[2]);
    }

}
