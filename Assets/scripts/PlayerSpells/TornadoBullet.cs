using UnityEngine;

public class TornadoBullet : MonoBehaviour
{
    public GameObject tornadoPrefab;
    public float delay = 2f;         // Delay before spawning the Tornado

    void Start()
    {
        // Start the delayed spawn process
        Invoke(nameof(SpawnTornado), delay);
    }

    void SpawnTornado()
    {

        Instantiate(tornadoPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
