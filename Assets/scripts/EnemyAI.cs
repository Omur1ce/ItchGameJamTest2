using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; 
    public float speed = 3f; 
    public float stoppingDistance = 2f; 

    private void Update()
    {
        if (target == null) return; 

        
        Vector2 direction = (target.position - transform.position).normalized;


        float distance = Vector2.Distance(transform.position, target.position);


        if (distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
