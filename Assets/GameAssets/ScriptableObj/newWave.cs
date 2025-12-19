using UnityEngine;

[CreateAssetMenu(fileName = "newWave", menuName = "Scriptable Objects/newWave")]
public class newWave : ScriptableObject
{
    //[DATA ONLY]
    public GameObject obstaclePrefab; //obstacle prefab for spawn
    public float movementSpeed; //movement speed of obstacle
    public int damageValue; //obstacle damage count
    public int numberOfObstacles; //Total num of spawned obstacles throughout wave
    public bool canEnemyShoot; //if toggled, the obstacle will fire the "bullet" instance
    public float spawnInterval; //Interval in seconds between spawns
    
    //Tried to work in some comments so that the codebase isn't a complete mess as mine usually are, certain occasions will feel and are basically just overexplained though.
}
