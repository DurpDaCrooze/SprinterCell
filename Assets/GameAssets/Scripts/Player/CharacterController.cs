using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //public vars
    public float moveSpeed;
    public float accelerationSpeed;
    
    //private vars
    private float moveVal = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int movementDirection = getInput();
        float moveVector = calculateMovement(movementDirection);
        applyMovement(moveVector);
    }

    int getInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return 1;
        } 
        if (Input.GetKey(KeyCode.A))
        {
            return -1;
        }

        return 0;
    }

    float calculateMovement(int direction)
    {
        if (direction != 0)
        {
            moveVal += accelerationSpeed;
        } else
        {
            moveVal = 0;
        }
        moveVal = Mathf.Clamp(moveVal, 0, moveSpeed);
        return (moveVal * Time.deltaTime * direction);
    }

    void applyMovement(float moveVal)
    {
        transform.Translate(moveVal, 0, 0);
    }
}
