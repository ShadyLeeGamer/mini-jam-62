using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isGrounded;

    public int dir;
    [HideInInspector] public int currentDir;

    public float moveSpeed;
    [HideInInspector] public float defMoveSpeed;
    [HideInInspector] public float defGravity;

    [HideInInspector] public Rigidbody2D rb;

    Animator animator;

    Citizen citizen;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        defGravity = rb.gravityScale;
        defMoveSpeed = moveSpeed;
    }

    void Update()
    {
        Vector2 move = new Vector2(dir * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        if (dir > 0)
            transform.eulerAngles = new Vector2(0, 0);
        if (dir < 0)
            transform.eulerAngles = new Vector2(0, 180);

        if (GetComponent<Zombie>())
        {
            if (isGrounded)
                animator.SetBool("Falling", false);
            else
                animator.SetBool("Falling", true);
        }

        if (GetComponent<Citizen>())
        {
            citizen = GetComponent<Citizen>();

            if (citizen.attack)
                dir = 0;
            else
                currentDir = dir;
            if (isGrounded)
            {
                if (rb.velocity.x != 0)
                    animator.SetBool("Move", true);
                else
                    animator.SetBool("Move", false);
            }
        }
    }
}
