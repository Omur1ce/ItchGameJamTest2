using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  
    public Transform[] spawnPoints;    
    public float initialSpawnInterval = 5f; 
    public GameObject spawnEffectPrefab; 
 
    public float minimumSpawnInterval = 1f;  
    public float spawnIntervalDecreaseRate = 0.1f; 
    public int initialEnemiesPerSpawn = 1;  
    public int maxEnemiesPerSpawn = 5; 
    public float enemiesPerSpawnIncreaseRate = 0.05f; // Rate at which the number of enemies per spawn increases
    public float initialDelay = 0.1f; // Delay for the very first spawn

    private float currentSpawnInterval;  
    private int currentEnemiesPerSpawn;
    private int totalSpawnPoints;  

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        currentEnemiesPerSpawn = initialEnemiesPerSpawn;
        totalSpawnPoints = spawnPoints.Length;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(initialDelay);
        SpawnEnemyWave();

        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);

            SpawnEnemyWave();

            // Reduce spawn interval, but not below minimum
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseRate, minimumSpawnInterval);

            // Increase the number of enemies per spawn, up to the maximum
            currentEnemiesPerSpawn = 1;
        }
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < currentEnemiesPerSpawn; i++)
        {
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, totalSpawnPoints)];
            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);

            if (spawnEffectPrefab != null)
            {
                Instantiate(spawnEffectPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
