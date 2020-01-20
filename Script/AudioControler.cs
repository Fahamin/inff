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


    public static AudioControler instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[PlayerPrefs.GetInt(SoundKey)];
        MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[PlayerPrefs.GetInt(MusicKey)];
    }

    public void OnClickSoundBtn()
    {

        if (PlayerPrefs.GetInt(SoundKey) == 1)
        {
            PlayerPrefs.SetInt(SoundKey, 0);
        }
        else
        {
            PlayerPrefs.SetInt(SoundKey, 1);
        }

        SoundButton.GetComponent<Image>().sprite = SoundBtnSprites[PlayerPrefs.GetInt(SoundKey)];

    }

    public void OnClickMusicBtn()
    {

        if (PlayerPrefs.GetInt(MusicKey) == 1)
        {
            PlayerPrefs.SetInt(MusicKey, 0);
        }
        else
        {
            PlayerPrefs.SetInt(MusicKey, 1);
        }

        MusicButton.GetComponent<Image>().sprite = MusicBtnSprites[PlayerPrefs.GetInt(MusicKey)];

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
