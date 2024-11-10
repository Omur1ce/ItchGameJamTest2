using UnityEngine;

public class Whirlwind : MonoBehaviour
{
    public int damageAmount = 0;           // Damage dealt per hit
    public float pushForce = 5f;            // Force to push enemies away
    public float particleEffectSize = 0.1f;
    public ParticleSystem damageEffect;     // Assign a particle effect prefab in the inspector

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();
        Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

        if (monsterHealth != null)
        {
            monsterHealth.TakeDamage(damageAmount);

            // Apply a push force to the enemy if they have a Rigidbody2D
            if (enemyRb != null)
            {
                Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }

            // Play damage effect
            if (damageEffect != null)
            {
                ParticleSystem effect = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
                var main = effect.main;
                main.startSizeMultiplier = particleEffectSize;
                Destroy(effect.gameObject, effect.main.duration); // Destroy effect after it finishes
            }

            Destroy(gameObject);
        }
    }
}