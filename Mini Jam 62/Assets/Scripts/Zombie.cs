using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    bool waterEffect = false;
    bool boosted = false;

    public string color;

    float boostSpeed_;

    Animator animator;

    Movement movement;

    public GameObject[] portalBlock;

    void Start()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        portalBlock = GameObject.FindGameObjectsWithTag("PortalBlock");

        if (boosted)
        {
            movement.moveSpeed = boostSpeed_;

            if (movement.isGrounded || waterEffect)
            {
                boosted = false;
                movement.moveSpeed = movement.defMoveSpeed;
            }
        }
        else if (!waterEffect)
            movement.moveSpeed = movement.defMoveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("BounceBlock") && color != "G")
        {
            boosted = true;
            boostSpeed_ = other.GetComponent<BounceBlock>().boostSpeed;

            movement.rb.velocity = Vector2.zero;
            movement.rb.AddForce(Vector2.up *
                other.gameObject.GetComponent<BounceBlock>().bounceForce,
                ForceMode2D.Impulse);
        }

        if (portalBlock.Length > 1 && color != "Y")
        {
            if (other.gameObject == portalBlock[0])
                Portal(portalBlock[1]);
            if (other.gameObject == portalBlock[1])
                Portal(portalBlock[0]);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("WaterBlock") && color != "B")
        {
            waterEffect = true;

            movement.rb.gravityScale = other.GetComponent<WaterBlock>().decGravity;
            movement.moveSpeed = other.GetComponent<WaterBlock>().decMoveSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WaterBlock") && color != "B")
        {
            waterEffect = false;

            movement.rb.gravityScale = movement.defGravity;
            movement.moveSpeed = movement.defMoveSpeed;
        }
    }

    void Portal(GameObject portalBlock_)
    {
        transform.position = new Vector2(portalBlock_.transform.position.x + 1 * movement.dir,
                                         portalBlock_.transform.position.y);
    }
}
