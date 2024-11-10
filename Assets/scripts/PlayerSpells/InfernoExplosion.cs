using UnityEngine;


public class InfernoExplosion : MonoBehaviour


{
    public int damageAmount = 10;
    public string element;
    public float particleEffectSize = 0.1f;
    public ParticleSystem damageEffect; // Assign a particle effect prefab in the inspector

    public float duration = 0.15f;

    void OnTriggerEnter2D(Collider2D other)
    {
    Absorb player = other.GetComponent<Absorb>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            if (!player.IsImmune(element))
            {
                playerHealth.TakeDamage(damageAmount);

                // Play damage effect
                if (damageEffect != null)
                {
                    ParticleSystem effect = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
                    var main = effect.main;
                    main.startSizeMultiplier = particleEffectSize;
                    Destroy(effect.gameObject, effect.main.duration);
                
            }
    }
    while(duration >= 0)
    {
        duration =- Time.deltaTime;

    }
    Destroy(gameObject);
}
    }
}
    
