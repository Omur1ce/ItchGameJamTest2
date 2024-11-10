using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {

        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;


        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Monster has died!");
        Destroy(gameObject);

    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
