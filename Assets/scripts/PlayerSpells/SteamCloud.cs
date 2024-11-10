using System.Collections;
using UnityEngine;

public class SteamCloud : MonoBehaviour
{
    public GameObject cloudPrefab;
    public int damagePerTick = 10;          // Damage dealt per tick
    public float tickInterval = 0.2f;        // Time interval between each damage tick
    public float effectRadius = 3f;        // Radius of the cloud effect
    public LayerMask targetLayer;          // Layer mask for which objects are affected (e.g., enemies)
    public float duration = 5f;            // Duration the cloud lasts in the air

    private void Start()
    {
        // Instantiate the cloud prefab at the current position
        Instantiate(cloudPrefab, transform.position, Quaternion.identity);

        // Start the cloud damage-over-time effect
        StartCoroutine(DamageOverTime());

        // Destroy the SteamCloud object after its duration
        Destroy(gameObject, duration);
    }

    private IEnumerator DamageOverTime()
    {
        float elapsedTime = 0f;

        // While the cloud is active
        while (elapsedTime < duration)
        {
            // Find all colliders within the effect radius
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, effectRadius, targetLayer);

            // Apply damage to each enemy within the radius
            foreach (Collider2D collider in colliders)
            {
                MonsterHealth monsterHealth = collider.GetComponent<MonsterHealth>();
                if (monsterHealth != null)
                {
                    monsterHealth.TakeDamage(damagePerTick);
                }
            }

            // Wait for the tick interval before applying damage again
            yield return new WaitForSeconds(tickInterval);

            // Increment the elapsed time by the tick interval
            elapsedTime += tickInterval;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the effect radius in the Scene view for visualization
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
