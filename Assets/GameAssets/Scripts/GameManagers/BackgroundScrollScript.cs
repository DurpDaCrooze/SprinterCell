using UnityEngine;

public class BackgroundScrollScript : MonoBehaviour
{
    //public vars
    public float scrollSpeed = -5;
    [SerializeField] private Vector3 backgroundStartPos;
    [SerializeField] private Vector3 backgroundEndPos;
    
    //objects
    public GameObject background;
    
    //internal use vars
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrollBackground();
        translateBothBackgrounds();
    }

    void scrollBackground()
    {
        if (background1.transform.position.y <= backgroundEndPos.y)
        {
            background1.transform.position = backgroundStartPos;
        }
        
        if (background2.transform.position.y <= backgroundEndPos.y)
        {
            background2.transform.position = backgroundStartPos;
        }
    }

    void translateBothBackgrounds()
    {
        background1.transform.Translate( 0, scrollSpeed * Time.deltaTime, 0);
        background2.transform.Translate(0, scrollSpeed * Time.deltaTime, 0);
    }   
    
    GameObject createBackground(bool startPos = true)
    {
        if (startPos)
        {
            return Instantiate(background, backgroundStartPos, Quaternion.identity);
        }
        else
        {
            return Instantiate(background, backgroundEndPos, Quaternion.identity);
        }
    }
}
