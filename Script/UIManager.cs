using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
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
        GameManager.instance.pause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

  
}

