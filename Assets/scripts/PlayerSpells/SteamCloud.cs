using System.Collections;
using UnityEngine;

public class SteamCloud : MonoBehaviour
{
    public int damageAmount = 20;
    public float damageInterval = 1f;
    public string element = "Water";
    public ParticleSystem damageEffect;
    public float particleEffectSize = 0.1f;

    private float timer;           // Timer to keep track of damage intervals

    void Start()
    {
        timer = damageInterval;
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
        if (other.GetComponent<MonsterHealth>() != null)
        {
            timer = damageInterval;
        }
    }
}
