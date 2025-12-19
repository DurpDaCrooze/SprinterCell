using System.Collections;
using System.Linq;
using UnityEngine;

public class EntityShoot : MonoBehaviour
{

    [SerializeField] int[] shootIntervalRandom = { 1, 4};
    public bool canShoot = false;

    public GameObject bulletPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (canShoot) StartCoroutine(shootTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootTimer()
    {
        yield return new WaitForSeconds(Random.Range(shootIntervalRandom[0], shootIntervalRandom[1]));
        shootBullet();
    }

    private void shootBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
