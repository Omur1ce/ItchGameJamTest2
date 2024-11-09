using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array to hold the enemy types
    public Transform[] spawnPoints;    // Array to hold possible spawn locations
    public float spawnInterval = 5f;   // Time in seconds between spawns

    private Transform player; 
    private void Start()
    {
        // Start the spawn loop
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(spawnInterval);

            // Choose a random enemy type
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];


            // Choose a random spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Spawn the enemy at the chosen spawn point
            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
            
        }
    }
}
