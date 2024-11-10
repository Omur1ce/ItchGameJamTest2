using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public string element;
    public float particleEffectSize = 0.1f;
    public ParticleSystem damageEffect; // Assign a particle effect prefab in the inspector

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Absorb player = other.GetComponent<Absorb>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            if (!player.IsImmune(element))
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("Player took Damage!");

                // Play damage effect
                if (damageEffect != null)
                {
                    ParticleSystem effect = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
                    var main = effect.main;
                    main.startSizeMultiplier = particleEffectSize;
                    Destroy(effect.gameObject, effect.main.duration); // Destroy effect after it finishes
                }
            }
            else
            {
                player.AbsorbElement(element);
                Debug.Log("Player is immune to this element!");
            }

            Destroy(gameObject); // Destroy the spell after hitting the player
        }
    }
}
