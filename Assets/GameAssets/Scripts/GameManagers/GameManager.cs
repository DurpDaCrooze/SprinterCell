using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    //general adjustments
    public float timesScale = 1f; //using this for testing and possibly for features, can slow down time ykyk (public purely for testing)
    public int score = 0;
    public int wave = 0;
    
    //Spawn Adjustments
    public float[] pgSpawnTimeRange = {3,7}; //point giver spawn time range
    public int pgSpawnCount;
    
    //object references
    public GameObject pointGiverPrefab;
    
    private Transform pointGiverSpawnerPos;
    
    //technical adjustments
    public float destroyObjectOutOfBoundsPadding = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void initVars()
    {
        pointGiverSpawnerPos = GameObject.Find("PointGiverSpawner").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnPointGivers()
    {
        for (int i = 0; i < pgSpawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(pgSpawnTimeRange[0], pgSpawnTimeRange[1]));
        }
    }

    void spawnObject(GameObject obj, Vector2 pos)
    {
        
    }
}
