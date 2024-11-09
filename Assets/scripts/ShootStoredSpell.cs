using UnityEngine;

public class ShootStoredSpell : MonoBehaviour
{
    public float spellSpeed = 10f;

    private Absorb absorbComponent;

    void Start()
    {
        absorbComponent = GetComponent<Absorb>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootSpell();
        }
    }

    void ShootSpell()
    {
        // Get the stored spell prefab from Absorb
        GameObject storedSpellPrefab = absorbComponent.GetStoredSpell();

        if (storedSpellPrefab != null)
        {
            // Instantiate a new spell at the player's position
            GameObject spellProjectile = Instantiate(storedSpellPrefab, transform.position, Quaternion.identity);

            // Calculate direction to mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Set the velocity of the spell
            Rigidbody2D rb = spellProjectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * spellSpeed;
            }

            // Clear the stored spell after shooting
            absorbComponent.ClearStoredSpell();
        }
        else
        {
            Debug.Log("No spell stored to shoot!");
        }
    }
}
