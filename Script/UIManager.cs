using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    int life_counter = 0;
    bool Extrabtnclick = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClickJumpBtn()
    {
        PlayerControl.playerInstance.jumpBtnEnter();
    }

    public void OnClickCrouchBtn()
    {
        PlayerControl.playerInstance.OnClickCrouch();

    }
    public void OnClickRelaseBtn()
    {
        PlayerControl.playerInstance.ReleaseCrouch();

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        GameManager.instance.tapbutton.gameObject.SetActive(false);
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
    public void Setting ()
    {
        // SceneManager.LoadScene(1);
    }

    public void Play()
    {
        SceneManager.LoadScene(0);
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
        Time.timeScale = 0;
    }

    public void resum ()
    {
        GameManager.instance.tapbutton.gameObject.SetActive(false);
        GameManager.instance.pause.gameObject.SetActive(false);
        Time.timeScale = 1;
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
  
}

