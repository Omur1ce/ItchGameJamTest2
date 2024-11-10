using UnityEngine;

public class TornadoBullet : MonoBehaviour
{
    public GameObject tornadoPrefab; // Assign the Tornado prefab in the inspector
    public float delay = 2f;         // Delay before spawning the Tornado

    void Start()
    {
        // Start the delayed spawn process
        Invoke(nameof(SpawnTornado), delay);
    }

    void SpawnTornado()
    {
        // Instantiate the tornado at the current position and rotation
        Instantiate(tornadoPrefab, transform.position, Quaternion.identity);

        // Destroy this spell object
        Destroy(gameObject);
    }
}
