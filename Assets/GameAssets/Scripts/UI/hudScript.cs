using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class hudScript : MonoBehaviour
{
    //public vars
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    private GameObject player;
    private CharacterController playerController;
    [SerializeField] private statsTracker stats;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //linking player istance
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Points: " + stats.currentScore);
        healthText.text = ("Health: " + player.GetComponent<PlayerController>().playerHealth);
    }
}
