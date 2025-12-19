using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public vars
    public float moveSpeed;
    public float playerHealth = 100; 
    public float accelerationSpeed;
    public float edgePadding;
    //objects
    
    //private vars
    private GameManager gameManager;
    private float moveVal = 0;
    private float minCap = 0;
    private float maxCap = 0;
    [SerializeField] private statsTracker stats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void Awake()
    {
        initEdgePadding();
    }

    private void initEdgePadding()
    {
        //Computing the edge padding here so that the arithmetic op doesn't run per frame :p
        minCap = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + edgePadding;
        maxCap = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - edgePadding;
    }
    
    // Update is called once per frame
    void Update()
    {
        //update sequence is [IMPORTANT], reminder to self to double check this in case of errors.
        float moveVector = calculateMovement(Input.GetAxisRaw( "Horizontal"));
        applyMovement(moveVector);
        clampMovementAtEdges();
        checkHealth();
    }

    void checkHealth()
    {
        //this usually wouldnt go here but I really dont have time im so sorry.
        if (playerHealth <= 0) //check health
        {
            if (stats.currentScore > stats.highScore) //update high sciore
            {
                stats.highScore = stats.currentScore;
            }
            stats.currentScore = 0; //reset current score
            gameManager.GetComponent<sceneSwitcher>().switchToScene("LoseScene");
        }
    }

    //clamp movement at edges for edge limits
    void clampMovementAtEdges()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minCap, maxCap), transform.position.y); 
    }
    
    float calculateMovement(float direction) //movement logic before translation
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

    //final transform translation
    void applyMovement(float moveVal)
    {
        transform.Translate(moveVal, 0, 0); //translate movement
    }
}
