using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnymeRunner : MonoBehaviour
{
    public static EnymeRunner enymeInstance;
    public float enymeSpeed ;


    // Start is called before the first frame update
    void Start()
    {
        enymeInstance = this;
        enymeSpeed = GameManager.instance.enemySpeed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * enymeSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("destroy"))
        {
            // Debug("TOUCH", "YES");
            Destroy(this.gameObject);

        }
    }
}

    