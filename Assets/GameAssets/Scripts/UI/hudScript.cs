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
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GetComponent<GameManager>(); //linking GameManager instance in the same gameobj so I just threw getcomponent
        
        //linking player istance
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Points: " + gameManager.score);
        healthText.text = ("Health: " + player.GetComponent<PlayerController>().playerHealth);
    }
}
