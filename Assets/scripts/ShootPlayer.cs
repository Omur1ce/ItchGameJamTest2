using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject spellPrefab;
    public Transform player;
    public float spellSpeed = 5f;
    public float shootingInterval = 2f;
    public float spellLifetime = 3f;

    private float shootTimer;

    void Update()
    {

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootingInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        if (player == null) return;

        GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);

        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * spellSpeed;
        Destroy(spell, spellLifetime);
    }

}
