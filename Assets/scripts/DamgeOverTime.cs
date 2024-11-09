using Unity.VisualScripting;
using UnityEngine;



public class DoT : MonoBehaviour
{
    public float period;

    public float duration;

    public int damageAmountPerSec = 10;

    public string element;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    float periodnow = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Absorb player = other.GetComponent<Absorb>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        while (true)
        {
        periodnow -= Time.deltaTime;
        
        if(period <= 0)
        {
            periodnow = period;
            if (player != null)
        {
            if (!player.IsImmune(element))
            playerHealth.TakeDamage(damageAmountPerSec);
            Debug.Log("Player took Damage!");
        }
        }
    }
}
}
