using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemont : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    Animator animator;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < -0.0001)
        {
            animator.SetBool("FacingLeft", true);
            animator.SetBool("FacingRight", false);
        }
        if (movement.x > 0.0001)
        {
            animator.SetBool("FacingLeft", false);
            animator.SetBool("FacingRight", true);
        }
    }

    void FixedUpdate()
    {

        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
