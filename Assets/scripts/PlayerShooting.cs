using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;      
    public float bulletSpeed = 10f;  

    public float shootCooldown = 0.5f;    

    private float lastShotTime;  

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShotTime + shootCooldown)
        {
            Shoot();
            lastShotTime = Time.time; 
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;  // Ensure we are in the same 2D plane if this is a 2D game

        // Calculate the direction from the fire point to the mouse position
        Vector2 direction = (mousePos - firePoint.position).normalized;

        // Instantiate the bullet at the firePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Set the bullet's velocity in the direction of the mouse
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;

        // Destroy the bullet after a certain time to avoid memory issues
        Destroy(bullet, 2f);
    }
}
