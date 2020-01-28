using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject gameOverpanel;
    public GameObject highSocreImg;
    public GameObject extraLife;
    public static GameManager instance;

    public Button tapbutton;

    public GameObject enyme0;
    public GameObject enyme;
    public GameObject enyme1;
    public GameObject enyme2;
    public GameObject flyEnyme;
    public GameObject enyme5;

    public GameObject destroyParticleEffect;
    public Transform particlePostion;

    public Transform enyme_starPostion;
    public Transform flyEnyme_postion;
    public Transform flyEnyme_postion2;
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
    int e_counter2;
    int e_counter3;
    int e_counter4;
    int e_counter5;

    public bool newScoreImg = false;
    public bool gameStar = false;
    public bool enymeCheckDestory;

    public string firstEntry;


    public GameObject Player;

    public void NewPlayer()
    {

        Instantiate(Player);
        Debug.Log("player comming");

    }

    private void Start()
    {
        NewPlayer();

        if (PlayerPrefs.HasKey(firstEntry))
        {
         //   Debug.Log("1 " + firstEntry + " " + PlayerPrefs.GetInt(firstEntry));
            LoadPlayerData();
        }
        else
        {
            Debug.Log("2");
            PlayerPrefs.SetInt(firstEntry, 1);

            
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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

    }


    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
      //  Debug.Log("H score: " + highScore);
        highScore = data.highScore;
      //  highScore = 0;

        //  Debug.Log("Hi score: " + highScore);
    }


    public void SavePlayerData()
    {
        if (score >= highScore)
        {
            highScore = score;
            newScoreImg = true;
        }

        SaveSystem.SavePlayer(this);
    }


    public void ParticleInstFun()
    {
        Instantiate(destroyParticleEffect, particlePostion.position, Quaternion.identity);
      //  Debug.Log("effect");
    }

    private void enymeSpeedUP()
    {
        if (t > 50)
        {
            scroll.instance.speed += 0.02f;
            enemySpeed +=.70f;

            if (spwnTimeCounter > .25)
            {
                spwnTimeCounter -= 0.05f;

            }
           
           
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
      //  PlayerPrefs.SetInt("high", score);
    }

    private void enymeChacker()
    {

        if (enymeCheckDestory != false)
        {
            SavePlayerData();
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
        e_counter2 += 2;
        e_counter3 += 2;
        e_counter4 += 2;
        e_counter5 += 2;

        if (score > 300 && e_counter1 > 8)
        {
            Instantiate(enyme, enyme_starPostion.position, Quaternion.identity);
            e_counter1 = 0;
        }

        else if (score > 150 && e_counter > 6)
        {
            Instantiate(enyme1, enyme_starPostion.position, Quaternion.identity);
            e_counter = 0;

        }
        else if (score > 600 && e_counter4 > 14)
        {
            Instantiate(flyEnyme, flyEnyme_postion2.position, Quaternion.identity);
            e_counter4 = 0;

        }

     /*  else if (score > 700 && e_counter5 > 16)
        {
            Instantiate(enyme5, enyme_starPostion.position, Quaternion.identity);
            e_counter5 = 0;

        }
        */

        else if (score > 400 && e_counter2 > 10)
        {
            Instantiate(flyEnyme, flyEnyme_postion.position, Quaternion.identity);
            e_counter2 = 0;
        }

        else if(e_counter3 > 5 && score > 100)
        {
            Instantiate(enyme2, enyme_starPostion.position, Quaternion.identity);
            e_counter3 = 0;
        }
        // Instantiate(flyEnyme, flyEnyme_postion.position, Quaternion.identity);

        else
           Instantiate(enyme0, enyme_starPostion.position, Quaternion.identity);


    }

}
