using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour
{

    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        //   Destroy(gameObject,particle.main.duration);
        Invoke("GameOver", particle.main.duration);
    }

    public void GameOver()
    {
        if (GameManager.instance.newScoreImg)
        {
            GameManager.instance.highSocreImg.gameObject.SetActive(true);

        }

        GameManager.instance.gameOverpanel.SetActive(true);

        Destroy(gameObject);
        Time.timeScale = 0;

     

        GameManager.instance.enymeCheckDestory = false;
       //  GameManager.instance.enemySpeed = 0f;
        //   scroll.instance.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
