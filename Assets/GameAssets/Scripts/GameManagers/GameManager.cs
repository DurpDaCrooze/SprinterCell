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
        pointGiverSpawnerPos = GameObject.Find("PointGiverSpawner").GetComponent<Transform>(); //link pointGiverSpawner gameObj
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startAllWaves() //initiate all wavess
    {
        //iterate through the waves
        foreach (newWave waves in allWaves)
        {
            yield return StartCoroutine(startWave(waves));

            yield return new WaitForSeconds(2f); //wait between waves
        }

        StartCoroutine(startAllWaves()); //loop at the end for endless gameplay
    }

    IEnumerator startWave(newWave wave)
    {
        for (int i = 0; i < wave.numberOfObstacles; i++)
        {
            //setup the path first (call my parse func)
            Transform[] pathArray = getRandomPathPoints().ToArray();
            
            //get instance refs :>
            GameObject obstacle = Instantiate(wave.obstaclePrefab, pathArray[0].position, Quaternion.identity);
            DamageDealer damageDealer = obstacle.GetComponent<DamageDealer>();
            GeneralEntityMovement generalEntityMovement = obstacle.GetComponent<GeneralEntityMovement>();
            EntityPathFollow entityPathFollow = obstacle.GetComponent<EntityPathFollow>();
            EntityShoot entityShoot = obstacle.GetComponent<EntityShoot>();
            
            //set wave data
            damageDealer.damageHandout = wave.damageValue;
            generalEntityMovement.speed = wave.movementSpeed;
            entityPathFollow.pathPoints = pathArray;
            entityShoot.canShoot = wave.canEnemyShoot;
            
            yield return new WaitForSeconds(wave.spawnInterval); //wait a few seconds between spawns
        }
    }

    public List<Transform> getRandomPathPoints() //Path parse function (Turns the transforms into a list)
    {
        print("parsing path points");
        List<Transform> pointList = new List<Transform>();
        
        GameObject path = paths[Random.Range(0, paths.Length)];
        
        print("Chose path: " + path.name);
        
        pointList.Add(path.transform); //add spawn pos (Parent Transform)
        //iterate through all children and add them to list
        foreach (Transform point in path.transform)
        {
            pointList.Add(point);
        }
        
        return pointList;
    }

    IEnumerator spawnPointGiversChron() //Timer (I call em chron jobs) to spawn point givers
    {
        //Iterate through spawn count to produce 10 as it says in the front sheet :o
        for (int i = 0; i < pgSpawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(pgSpawnTimeRange[0], pgSpawnTimeRange[1]));
            spawnObject(pointGiverPrefab, pointGiverSpawnerPos.position);

        }
    }

    void spawnObject(GameObject obj, Vector2 pos) //this is redundant, was going to add type safety for instantiations until I found out they natively return the object, but it's in my code now so it'll stay
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
