using System;
using UnityEditor.UI;
using UnityEngine;

public class PointGiver : MonoBehaviour
{
    public int pointHandout = 5;
    
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initVars();
    }

    void initVars()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Collision");
        if(other.CompareTag("Player"))
        {
            givePoints(pointHandout);
            Destroy(gameObject);
        }
    }

    private void givePoints(int pointCount)
    {
        gameManager.score += pointCount;
    }
}
