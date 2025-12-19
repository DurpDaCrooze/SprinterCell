using System;
using UnityEngine;

public class EntityPathFollow : MonoBehaviour
{
    public Transform[] pathPoints;
    private int targetPoint = 1;
    private float speed = 6;
    int moveDir = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Math.Abs(GetComponent<GeneralEntityMovement>().speed);
    }

    // Update is called once per frame
    void Update()
    {
        //check if passed target point
        if (transform.position.y < pathPoints[targetPoint].position.y)
        {
            if(targetPoint < (pathPoints.Length -1)) targetPoint++;
        }

        bool isRight = transform.position.x < pathPoints[targetPoint].position.x; //store wether obj is right or not via bool

        //movement logic (crude but it works)
        if (isRight)
        {
            moveDir = 1; //shift right if object is on the right
        }
        else
        {
            moveDir = -1; //else move left
        }

        
        transform.Translate(new Vector3(speed * Time.deltaTime * moveDir , 0, 0)); // move left
    }
}
