using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    public static scroll instance;
    public float speed = 0.5f;
    public Renderer bgRender;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRender.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}
