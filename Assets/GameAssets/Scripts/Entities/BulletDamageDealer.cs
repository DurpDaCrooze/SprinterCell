using System;
using UnityEngine;

public class BulletDamageDealer : MonoBehaviour
{
    
    public int damageHandout = 1;
    
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
        //check if collision is with player (via tag) (again)
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            dealDamage(player);
            Destroy(gameObject);
        }
    }

    //output damage
    private void dealDamage(PlayerController player)
    {
        player.playerHealth -= damageHandout; //subtract player health (calling gameManager obj here)
    }
}
