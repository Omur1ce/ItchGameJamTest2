using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject gameOverUI; 

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
        Debug.Log("Player has died!");
        ShowGameOverScreen();

    }

    private void ShowGameOverScreen()
    {
        Time.timeScale = 0f; 
        gameOverUI.SetActive(true); 
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
