using Unity.VisualScripting;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public string element;
    public float particleEffectSize = 0.1f;
    public ParticleSystem damageEffect; // Assign a particle effect prefab in the inspector

    public GameObject ChildBullet;
    void Start()
    {
    }

    bool Immune;
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
                    Immune = false;
                
                }
            }
            else
            {
                player.addToStoredElements(element);  
                Debug.Log("Player is immune to this element!");
                Debug.Log("absorbed");
                Immune = true;

            }
           

            Destroy(gameObject); // Destroy the spell after hitting the player
    
        }
    }

    void OnDestroy()
    {
        if (ChildBullet != null && Immune == false)
        {
            Instantiate(ChildBullet);  // Spawn Children on death.
        }
    }
    
}
