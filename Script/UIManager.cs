using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  
    int life_counter = 0;
    bool Extrabtnclick = true;

    public GameObject audioOff;
    public GameObject audioON;

    public GameObject musicON;
    public GameObject musicFF;

    // Start is called before the first frame update
    void Start()
    {

    //    Debug.Log("music key: " + AudioControler.instance.MusicKey);
        iconCheck();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void iconCheck()
    {
        int audio = PlayerPrefs.GetInt("audio");
        if (PlayerPrefs.HasKey("audio"))
        {
            if (audio == 1)
            {
                audioON.SetActive(false);
                audioOff.SetActive(true);

            }
            if (audio == 0)
            {
                audioON.SetActive(true);
                audioOff.SetActive(false);
            }
        }

        if (PlayerPrefs.HasKey("music"))
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                musicON.SetActive(true);
                musicFF.SetActive(false);
            }
            if (PlayerPrefs.GetInt("music") == 1)
            {
                musicON.SetActive(false);
                musicFF.SetActive(true);
            }

        }
    }
   

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        GameManager.instance.tapbutton.gameObject.SetActive(false);
        AudioManager.instance.PlayAudio(0);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayAudio(0);
    }
    public void Setting ()
    {
        // SceneManager.LoadScene(1);
        AudioManager.instance.PlayAudio(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);

        AudioManager.instance.PlayAudio(0);

        // GameManager.instance.tapbutton.gameObject.SetActive(false);
        // GameManager.instance.pause.gameObject.SetActive(false);
    }
    public void Tapbutton()
    {

        GameManager.instance.gameStar = true;
        Time.timeScale = 1;
        GameManager.instance.tapbutton.gameObject.SetActive(false);
    }
    public void Leaderboard()
    {

    }
    public void Pasue ()
    {
        GameManager.instance.pause.gameObject.SetActive(true);
        AudioManager.instance.PlayAudio(0);
        Time.timeScale = 0;
    }

    public void resum ()
    {
        GameManager.instance.tapbutton.gameObject.SetActive(false);
        GameManager.instance.pause.gameObject.SetActive(false);
        Time.timeScale = 1;
        AudioManager.instance.PlayAudio(0);
    }
    public void ExtraLife()
    {
        life_counter++;
      
        if(life_counter<=1)
        {
            Extrabtnclick = false;
            GameManager.instance.enymeCheckDestory = true;
            Time.timeScale = 1;
            GameManager.instance.gameOverpanel.SetActive(false);

            GameManager.instance.NewPlayer();
            GameManager.instance.extraLife.SetActive(false);
        }

      else if(!Extrabtnclick)
                {
                GameManager.instance.extraLife.SetActive(false);
                PlayerControl.playerInstance.finalPlayerDestroy();
               }

    }
  
    
    public void MusicON()
    {
                 PlayerPrefs.SetInt("music", 1);
                 musicON.SetActive(false);
                 musicFF.SetActive(true);
    }

    public void MusicOFF()
    {
        PlayerPrefs.SetInt("music", 0);
        musicON.SetActive(true);
        musicFF.SetActive(false);
    }

    public void AudioOFF()
    {
        PlayerPrefs.SetInt("audio", 0);
        audioON.SetActive(true);
        audioOff.SetActive(false);
    }
    public void AudioON()
    { 
     
        PlayerPrefs.SetInt("audio", 1);
        audioON.SetActive(false);
        audioOff.SetActive(true);
    }





    public void musicONOFF()
    {
        if(PlayerPrefs.GetInt("music")==0)
        {
            musicON.SetActive(true);
            musicFF.SetActive(false);
        }
        else
        musicON.SetActive(false);
        musicFF.SetActive(true);
    }
}

