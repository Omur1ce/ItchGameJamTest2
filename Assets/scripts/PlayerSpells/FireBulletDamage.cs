using UnityEngine;

public class FireBulletDamage : MonoBehaviour
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
        MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();
        monsterHealth.TakeDamage(damageAmount);

                
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
