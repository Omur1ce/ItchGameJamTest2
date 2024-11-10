using UnityEngine;

public class Geyser : MonoBehaviour
{
    public int damageAmount = 20;         
    public float effectRadius = 3f;       
    public LayerMask targetLayer;         
    public ParticleSystem effectVisual;   

    //private float delay = 1f;             // Delay before damage is applied

    void Start()
    {

    }

    void PerformAreaDamage()
    {
        // Find all colliders within the specified radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, effectRadius, targetLayer);

        // Loop through each collider and apply damage
        foreach (Collider2D collider in colliders)
        {
            MonsterHealth monsterHealth = collider.GetComponent<MonsterHealth>();
            if (monsterHealth != null)
            {
                monsterHealth.TakeDamage(damageAmount);
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Draw the effect radius in the Scene view for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
