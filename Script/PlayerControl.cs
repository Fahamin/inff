using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
  public  GameObject player;
//  public  Transform player_Postion;

    public float playerSpeed;
    private Rigidbody2D rb2d;
    public bool onGround = false;

    public Animator animator;
    CircleCollider2D circleCollider;


    public static PlayerControl playerInstance;
    // Start is called before the first frame update

    void Start()
    {
       
        playerInstance = this;
        animator = gameObject.GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();

        circleCollider = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.gameStar)
        {
            animator.enabled = true;
        }

      
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
      

            if(animator.GetBool("jump"))
            {
                jumpBtnexit();

            }
            
        }
        if (collision.gameObject.CompareTag("enyme"))
        {
            playerDestory();

        }

    }

  

    public void playerDestory()
    {
       
        AudioManager.instance.PlayAudio(3);
        Destroy(this.gameObject);
        GameManager.instance.ParticleInstFun();
      
    }

    public void finalPlayerDestroy()
    {
        Destroy(this.gameObject);
        GameManager.instance.gameOverpanel.SetActive(true);
          GameManager.instance.enemySpeed = 0f;
          scroll.instance.speed = 0f;
    }

    public void ReleaseCrouch()
    {
        if(animator != null)
        {
            animator.SetBool("crouch", false);
            circleCollider.enabled = true;

        }
    }
     
    public void OnClickCrouch()
    {
        if (animator != null)
        {
            AudioManager.instance.PlayAudio(2);
            animator.SetBool("crouch", true);
            circleCollider.enabled = false;
        }
    }

   

    public void jumpBtnexit()
    {
        if (animator != null)
        {
            animator.SetBool("jump", false);
        }
    }

    public void jumpBtnEnter()
    {
        if(animator != null )
        {

            AudioManager.instance.PlayAudio(1);
            animator.SetBool("jump", true);
          
        }
    }
   
}
