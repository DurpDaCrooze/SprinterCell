using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] public List<newWave> allWaves;
    [SerializeField] public GameObject[] paths;
    
    private Transform pointGiverSpawnerPos;
    
    //technical adjustments
    public float destroyObjectOutOfBoundsPadding = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initVars();
        StartCoroutine(spawnPointGiversChron());
        StartCoroutine(startAllWaves());
    }

    void initVars()
    {
        pointGiverSpawnerPos = GameObject.Find("PointGiverSpawner").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startAllWaves()
    {
        foreach (newWave waves in allWaves)
        {
            yield return StartCoroutine(startWave(waves));

            yield return new WaitForSeconds(2f);
        }

        StartCoroutine(startAllWaves());
    }

    IEnumerator startWave(newWave wave)
    {
        for (int i = 0; i < wave.numberOfObstacles; i++)
        {
            //setup the path first
            Transform[] pathArray = getRandomPathPoints().ToArray();
            
            //get instance refs :>
            GameObject obstacle = Instantiate(wave.obstaclePrefab, pathArray[0].position, Quaternion.identity);
            DamageDealer damageDealer = obstacle.GetComponent<DamageDealer>();
            GeneralEntityMovement generalEntityMovement = obstacle.GetComponent<GeneralEntityMovement>();
            EntityPathFollow entityPathFollow = obstacle.GetComponent<EntityPathFollow>();
            
            //set wave data
            damageDealer.damageHandout = wave.damageValue;
            generalEntityMovement.speed = wave.movementSpeed;
            entityPathFollow.pathPoints = pathArray;
            
            yield return new WaitForSeconds(wave.spawnInterval);
        }
    }

    public List<Transform> getRandomPathPoints()
    {
        print("parsing path points");
        List<Transform> pointList = new List<Transform>();
        
        GameObject path = paths[Random.Range(0, paths.Length)];
        
        pointList.Add(path.transform);
        foreach (Transform point in path.transform)
        {
            print("Adding point to list:" + point.position);
            pointList.Add(point);
            print("Added point to list!");
        }
        
        return pointList;
    }

    IEnumerator spawnPointGiversChron()
    {
        print("Coroutine started: spawnPointGiversChron");
        for (int i = 0; i < pgSpawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(pgSpawnTimeRange[0], pgSpawnTimeRange[1]));
            print("Spawning point giver: " + i);
            spawnObject(pointGiverPrefab, pointGiverSpawnerPos.position);

        }
    }

    void spawnObject(GameObject obj, Vector2 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
