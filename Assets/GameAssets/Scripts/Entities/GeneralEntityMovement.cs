using System;
using UnityEngine;

public class GeneralEntityMovement : MonoBehaviour
{

    public float speed;

    private GameManager gameManager;

    private void Awake()
    {
        //set speed to negative
        if (speed > 0) speed = -speed;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        print(gameManager.timesScale);
    }

    // Update is called once per frame
    void Update()
    {
        moveEntity();
    }

    void moveEntity()
    {
        transform.Translate(0, speed * Time.deltaTime * gameManager.timesScale, 0);
    }
}
