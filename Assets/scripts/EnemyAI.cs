using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject spellPrefab;
    public Transform player;
    public float spellSpeed = 5f;
    public float shootingInterval = 2f;
    public float spellLifetime = 3f;

    private float shootTimer;

    public Transform target; 
    public float speed = 3f; 
    public float stoppingDistance = 2f; 

    private Vector2 direction;

    private float distance;

    void Update()
    {

        if (target == null) return; 

        
        direction = (target.position - transform.position).normalized;


        distance = Vector2.Distance(transform.position, target.position);


        if (distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }else{
            shootTimer += Time.deltaTime;
        if (shootTimer >= shootingInterval)
        {
            Debug.Log("should be shooting");
            ShootAtPlayer();
            shootTimer = 0f;
        }
        }

    }



    public void ShootAtPlayer()
    {
        

        GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);

        Vector2 direction = (player.position - transform.position).normalized;

        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * spellSpeed;
        Destroy(spell, spellLifetime);
    }

}