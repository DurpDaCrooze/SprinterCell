using UnityEngine;

[CreateAssetMenu(fileName = "newWave", menuName = "Scriptable Objects/newWave")]
public class newWave : ScriptableObject
{
    public GameObject obstaclePrefab;
    public float movementSpeed;
    public int damageValue;
    public int numberOfObstacles;
    public bool canEnemyShoot;
    public float spawnInterval; 
}
