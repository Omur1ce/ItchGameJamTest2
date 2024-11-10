using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour
{
    public int healAmount = 20;
    public float destroyDelay = 1f;

    void Start()
    {
        PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth + healAmount, playerHealth.maxHealth);
            Debug.Log("Player healed by " + healAmount + ". Current health: " + playerHealth.GetCurrentHealth());

            StartCoroutine(DestroyAfterDelay());
        }
        else
        {
            Debug.LogError("PlayerHealth component not found on any GameObject.");
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
