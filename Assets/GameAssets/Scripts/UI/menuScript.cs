using TMPro;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    
    [SerializeField] public statsTracker stats;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateHighScoreText(); //update high score text, I know i should do this in a dedicated UI script but im sticking with a monolithic struct here for simplicities sake.
    }

    void updateHighScoreText()
    {
        scoreText.text = ("High Score: " + stats.highScore);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
