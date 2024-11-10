using UnityEngine;

public class Inferno : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageInterval = 1f; 
    public string element = "Fire";
    public ParticleSystem damageEffect;
    public float particleEffectSize = 0.2f;

    public float duration;
    
    public GameObject targetObject;

    public GameObject childObject;
    private float timer;                   // Timer to keep track of damage intervals

    void Start()
    {
        timer = damageInterval;
        Destroy(gameObject, duration);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();

        if (monsterHealth != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                monsterHealth.TakeDamage(damageAmount);
                timer = damageInterval;

                if (damageEffect != null)
                {
                    ParticleSystem effect = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
                    var main = effect.main;
                    main.startSizeMultiplier = particleEffectSize;
                    Destroy(effect.gameObject, effect.main.duration);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Reset the timer when the enemy leaves the water wall
        if (other.GetComponent<MonsterHealth>() != null)
        {
            timer = damageInterval;
        }
    }

    void OnDestroy()
    {
        if(childObject != null)
        {
        Instantiate(childObject, targetObject.transform.position, Quaternion.identity);
        }
    }
}
