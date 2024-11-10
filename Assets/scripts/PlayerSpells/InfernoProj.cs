using UnityEngine;

public class InfernoProj : MonoBehaviour
{

    public GameObject InfernoCloud;
    public int damageAmount = 4;
    public string element;
    public float particleEffectSize = 0.1f;
    public ParticleSystem damageEffect; // Assign a particle effect prefab in the inspector
    public float duration = 5f;
    void Start()
    {
        Destroy(gameObject, duration);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();
        monsterHealth.TakeDamage(damageAmount);
        Instantiate(InfernoCloud, transform.position, Quaternion.identity);

        if (damageEffect != null)
        {
            ParticleSystem effect = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
            var main = effect.main;
            main.startSizeMultiplier = particleEffectSize;
            Destroy(effect.gameObject, effect.main.duration); // Destroy effect after it finishes
        }
        

    }
    void OnDestroy()
    {
        Instantiate(InfernoCloud, transform.position, Quaternion.identity);
    }
}
      
       


