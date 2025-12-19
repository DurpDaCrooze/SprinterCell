using UnityEngine;

public class PointGiverSpawner : MonoBehaviour
{
    public float speed = 3f;
    public float edgePadding = 1f;
    
    private float minCap;
    private float maxCap;
    private int movedir = -1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        moveSideToSide(); //call func for movement
    }

    //movement function
    private void moveSideToSide()
    {   //flip flop switch for side to side movement
        if(transform.position.x >= maxCap) movedir = -1;
        if(transform.position.x <= minCap) movedir = 1;
        
        transform.Translate(speed * Time.deltaTime * movedir, 0, 0); //apply movement
    }
}
