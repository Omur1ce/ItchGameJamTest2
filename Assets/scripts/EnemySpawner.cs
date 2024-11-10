using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  
    public Transform[] spawnPoints;    
    public float initialSpawnInterval = 5f;  
    public float minimumSpawnInterval = 1f;  
    public float spawnIntervalDecreaseRate = 0.1f; 

    private float currentSpawnInterval;  
    private int maxSpawnRange = 1;  
    private int totalSpawnPoints;  

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        totalSpawnPoints = spawnPoints.Length;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);

            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            maxSpawnRange = Mathf.Min(totalSpawnPoints, maxSpawnRange + 1);

            Transform spawnPoint = spawnPoints[Random.Range(0, maxSpawnRange)];

            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);

            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseRate, minimumSpawnInterval);
        }
    }
}
