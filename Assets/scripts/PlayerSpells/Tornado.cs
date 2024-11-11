using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float pullRadius = 5f;             // Radius within which objects are pulled
    public float pullForce = 5;             // Strength of the pull force
    public float duration = 0.5f;               // Duration the spell stays active
    public LayerMask pullableLayers;          // Layers to affect (e.g., Enemy, Rigidbodies)

    void Start()
    {

        Destroy(gameObject, duration);
    }

    void FixedUpdate()
    {
        // Find all colliders within the specified radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius, pullableLayers);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Calculate the direction towards the spell center
                Vector2 direction = (transform.position - rb.transform.position).normalized;

                // Apply a force towards the center
                rb.AddForce(direction * pullForce * Time.fixedDeltaTime, ForceMode2D.Force);
            }
        }
    }
    private void OnDestroy()
    {
        
    }
}
