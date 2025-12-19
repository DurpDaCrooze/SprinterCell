using System.Collections;
using System.Linq;
using UnityEngine;

public class EntityShoot : MonoBehaviour
{

    public float[] shootIntervalRandom = {0.3f, 3f};
    public bool canShoot = false;

    public GameObject bulletPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (canShoot) StartCoroutine(shootTimer()); //checking if the damage dealer bool is toggles so that shooting is enabled
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootTimer() //starting chron for randomized shoot events
    {
        yield return new WaitForSeconds(Random.Range(shootIntervalRandom[0], shootIntervalRandom[1])); //await so enemy doesn't fire immedietly on spawn
        
        shootBullet(); //call shoot func
        
        StartCoroutine(shootTimer()); //calling self to loop shooting
    }

    private void shootBullet() //shoot func
    {
        //instintiate bullet prefab at obstacle pos
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
