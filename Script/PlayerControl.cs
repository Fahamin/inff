using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    GameObject player;
    public float playerSpeed;
    private Rigidbody2D rb2d;
    public bool onGround = false;

  //  public Animator crouch;
    //CircleCollider2D circleCollider;
  

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

     //   crouch = gameObject.GetComponent<Animator>();
       // circleCollider = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        jumpPlayer();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;

      //  crouch.SetBool("crouch", false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            jumpPlayer();
        }
        if (collision.gameObject.CompareTag("enyme"))
        {
            playerDestory();

        }

    }

    public void playerDestory()
    {
        Destroy(this.gameObject);
        GameManager.instance.gameOverpanel.SetActive(true);
     //   reStartBtn.gameObject.SetActive(true);
        GameManager.instance.enymeCheckDestory = false;
        GameManager.instance.enemySpeed = 0f;
        scroll.instance.speed = 0f;
       
    }
    public void ReleaseCrouch()
    {
     //   crouch.SetBool("crouch", false);
       // circleCollider.enabled = true;
    }

    public void OnClickCrouch()
    {
       // crouch.SetBool("crouch", true);
        //circleCollider.enabled = false;
    }

    public void jumpPlayer()
    {

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
         
            rb2d.AddForce(Vector2.up * playerSpeed, ForceMode2D.Impulse);
            onGround = false;

        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround == true)
        {
         //   crouch.SetBool("crouch", true);
            rb2d.AddForce(Vector2.up * playerSpeed, ForceMode2D.Impulse);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           // crouch.SetBool("crouch", true);
            //circleCollider.enabled = false;
        }


    }

    public void jumpBtn()
    {
        if(onGround == true)
        {
            rb2d.AddForce(Vector2.up * playerSpeed, ForceMode2D.Impulse);
            onGround = false;
        }

        if (Input.touchCount == 1 && onGround == true)
        {
            rb2d.AddForce(Vector2.up * playerSpeed, ForceMode2D.Impulse);
            //onGround = false;
        }

    }

  
}
