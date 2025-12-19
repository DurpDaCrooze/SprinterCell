using UnityEngine;

public class EntityPathFollow : MonoBehaviour
{
    public Transform[] pathPoints;
    private int targetPoint = 1;
    private int speed = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if passed target point
        if (transform.position.y < pathPoints[targetPoint].position.y)
        {
            targetPoint++;
        }
        
        //move y towards target point
        if (transform.position.x < pathPoints[targetPoint].position.x)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }else if (transform.position.x < pathPoints[targetPoint].position.x)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * -1, 0, 0));
        }
    }
}
