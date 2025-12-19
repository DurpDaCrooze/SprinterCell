using System;
using UnityEngine;

public class GeneralEntityMovement : MonoBehaviour
{

    //public vars
    public float speed;
    public float destroyObjectPadding;
    
    private GameManager gameManager;
    private Camera camera;
    private float outofboundsy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initVars();
        //set speed to negative
        if (speed > 0) speed = -speed;
    }

    void initVars()
    {
        gameManager = FindObjectOfType<GameManager>();
        outofboundsy = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        outofboundsy -= gameManager.destroyObjectOutOfBoundsPadding;
    }

    // Update is called once per frame
    void Update()
    {
        moveEntity();
        destroyEntityOffScreen();
    }

    void moveEntity()
    {
        transform.Translate(0, speed * Time.deltaTime * gameManager.timesScale, 0);
    }

    void destroyEntityOffScreen()
    {
        if (transform.position.y < (outofboundsy-destroyObjectPadding))
        {
            Destroy(gameObject);
        }
    }
}
