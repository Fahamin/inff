using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{

    public GameObject SoundButton;
    public GameObject MusicButton;

    public Sprite[] SoundBtnSprites;
    public Sprite[] MusicBtnSprites;


    public string SoundKey = "_sound";
    public string MusicKey = "_music";



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(SoundKey))
        {
            if (PlayerPrefs.GetInt(SoundKey) == 1)
            {
                
                SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[0];
            }
            else
            {
                SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[1];
              
            }
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[1];
       
        }


        if (PlayerPrefs.HasKey(MusicKey))
        {
            if (PlayerPrefs.GetInt(MusicKey) == 1)
            {
                MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[0];
                
            }
            else
            {
                MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[1];
              
            }
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[1];
       
        }
    }

    public void OnClickSoundBtn()
    {
        if (PlayerPrefs.HasKey(SoundKey))
        {
            if(PlayerPrefs.GetInt(SoundKey) == 1)
            {
                PlayerPrefs.SetInt(SoundKey,0);
                SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[0];
            }
            else
            {
                SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[1];
                PlayerPrefs.SetInt(SoundKey, 1);
            }
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[1];
            PlayerPrefs.SetInt(SoundKey, 1);
        }

        

    }

    public void OnClickMusicBtn()
    {
        if (PlayerPrefs.HasKey(MusicKey))
        {
            if (PlayerPrefs.GetInt(MusicKey) == 1)
            {
                MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[0];
                PlayerPrefs.SetInt(MusicKey, 0);
            }
            else
            {
                MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[1];
                PlayerPrefs.SetInt(MusicKey, 1);
            }
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[1];
            PlayerPrefs.SetInt(MusicKey, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
