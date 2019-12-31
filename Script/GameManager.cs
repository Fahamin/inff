using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject gameOverpanel;
    public static GameManager instance;
    public Button tapbutton;


    public GameObject enyme;
    public GameObject enyme1;
    public GameObject enyme2;
    public Transform enyme_starPostion;

    //public Transform flystarPostion;
    public float enemySpeed = 10f;
    float count;
    public float spwnTimeCounter;
    //main panel
    public Text scoreText;
    public Text high_scoreText;
    //gameoverpanel
    public Text game_scoreText;
    public Text game_high_scoreText;

    public float scoreCounter=0;
    public int highScore;
    public int score;
    float t;
    int e_counter;
    int e_counter1;
    public bool enymeCheckDestory;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("high");
        gamepanelhide();
        instance = this;
        Time.timeScale = 0;
        enymeCheckDestory = true;
        enymyCreator();
    }

  public void  gamepanelhide()
    {
        gameOverpanel.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        score = (int)scoreCounter;

        enymeChacker();

        if(score>highScore)
        {
            highScoreset(score);
        }
    }

    private void enymeSpeedUP()
    {
        if (t > 50)
        {
            spwnTimeCounter -= 0.04f;
            scroll.instance.speed+= 0.03f;
            enemySpeed += 1;
            t = 0;

        }
        else
        {
            t += Time.deltaTime * 10;
        }
    }

    private void scorView()
    {
       
        scoreCounter += Time.deltaTime * 10;
        scoreText.text = score.ToString();
        high_scoreText.text = highScore.ToString();

        game_scoreText.text = score.ToString();
        game_high_scoreText.text = highScore.ToString();
    }

    public void highScoreset(int score)
    {
        PlayerPrefs.SetInt("high", score);
    }
    private void enymeChacker()
    {

        if (enymeCheckDestory != false)
        {
            enymeSpeedUP();
            scorView();
            if (count >= spwnTimeCounter)
            {
                enymyCreator();
            }
            else
                count += Time.deltaTime;
        }

    }

    private void enymyCreator()
    {
        count = 0;

        //  Instantiate(enyme, starPostion.position, Quaternion.identity);

        e_counter += 2;
        e_counter1 += 2;


        if (score > 300 && e_counter1 > 8)
        {
            Instantiate(enyme, enyme_starPostion.position, Quaternion.identity);
            e_counter1 = 0;
        }

        else if (score > 150 && e_counter > 4)
        {
            Instantiate(enyme1, enyme_starPostion.position, Quaternion.identity);
            e_counter = 0;

        }

        else
            Instantiate(enyme2, enyme_starPostion.position, Quaternion.identity);



    }






    public void Tapbutton()
    {
        Time.timeScale = 1;
        tapbutton.gameObject.SetActive(false);
    }
}
