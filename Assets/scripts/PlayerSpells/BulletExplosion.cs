using UnityEngine;

public class AoESpell : MonoBehaviour
{
    public int damageAmount = 20;       // Damage dealt to each enemy in the area
    public float effectRadius = 3f;     // Radius of the area effect
    public LayerMask targetLayer;       // Layer mask to specify which objects to affect
    public ParticleSystem effectVisual; // Optional: Visual effect for the AoE

    void Start()
    {
        // Trigger the area damage effect
        PerformAreaDamage();

        // Play effect visuals if assigned
        if (effectVisual != null)
        {
            ParticleSystem effectInstance = Instantiate(effectVisual, transform.position, Quaternion.identity);
            Destroy(effectInstance.gameObject, effectInstance.main.duration); // Destroy effect after it finishes
        }

        // Destroy the spell object immediately
        Destroy(gameObject);
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
    }

    void OnDrawGizmosSelected()
    {
        // Draw the effect radius in the Scene view for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
