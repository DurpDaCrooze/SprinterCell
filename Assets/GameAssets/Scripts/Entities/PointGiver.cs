using System;
using UnityEditor.UI;
using UnityEngine;

public class PointGiver : MonoBehaviour
{
    //public vars
    public int pointHandout = 5; //amount of points handed out per pointGiver collected
    
    //private vars
    private GameManager gameManager; //link gameManager instance
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initVars();
    }

    void initVars() //init vars
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if collision is with player (via tag)
        if(other.CompareTag("Player"))
        {
            givePoints(pointHandout); //give points
            Destroy(gameObject);
        }
    }

    private void givePoints(int pointCount) //partially redundant for such a simple game although in the long run this would've been useful (appologies if the typing feels informal, im on 3 hours of sleep)
    {
        gameManager.score += pointCount;
    }
}
