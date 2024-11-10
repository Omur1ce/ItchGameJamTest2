using UnityEngine;


public class InfernoExplosion : MonoBehaviour
{
    public int damageAmount = 20;       // Damage dealt to each enemy in the area
    public float effectRadius = 3f;     // Radius of the area effect
    public LayerMask targetLayer;       // Layer mask to specify which objects to affect
    public ParticleSystem effectVisual; // Optional: Visual effect for the AoE

    public float particleEffectSize;
    void Start()
    {
        // Trigger the area damage effect
        PerformAreaDamage();



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

                // Play effect visuals if assigned
        if (effectVisual != null)
        {
            ParticleSystem effect = Instantiate(effectVisual, transform.position, Quaternion.identity);
                    var main = effect.main;
                    main.startSizeMultiplier = particleEffectSize;
                    Destroy(effect.gameObject, effect.main.duration);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the effect radius in the Scene view for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
