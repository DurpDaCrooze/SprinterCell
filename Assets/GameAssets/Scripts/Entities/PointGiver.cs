using System;
using UnityEditor.UI;
using UnityEngine;

public class PointGiver : MonoBehaviour
{
    //public vars
    public int pointHandout = 5; //amount of points handed out per pointGiver collected
    [SerializeField] public statsTracker stats;
    public bool endLevelOnDestroy = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            givePoints(pointHandout); 
            Destroy(gameObject); //if not then just destroy//give points
        }
    }
    
    private void givePoints(int pointCount) //partially redundant for such a simple game although in the long run this would've been useful (appologies if the typing feels informal, im on 3 hours of sleep)
    {
        stats.currentScore += pointCount;
    }
    
    private void endLevelSequence()
    {
        
    }


    void OnDestroy()
    {
        if (endLevelOnDestroy) endLevelSequence();
    }
    
}
