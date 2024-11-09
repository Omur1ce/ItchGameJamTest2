using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemont : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    Animator animator;
    private bool facingLeft = true;

    void Start()
    {
        //animator.SetBool("isRunning", false);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0 && !facingLeft)
        {
            Flip();
        }
        if (movement.x > 0 && facingLeft)
        {
            Flip();
        }

        if (Mathf.Abs(movement.x + movement.y) > 5)
        {
            animator.SetBool("isRunning", true);
        }
    }


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }



    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
