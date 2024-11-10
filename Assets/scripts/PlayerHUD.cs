using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText; // Use TextMeshProUGUI if using TextMeshPro, or Text if using normal Text
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.GetCurrentHealth();
        
        UpdateHealthText();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetCurrentHealth();
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth.GetCurrentHealth() + "/" + playerHealth.maxHealth;
        }
    }
}
