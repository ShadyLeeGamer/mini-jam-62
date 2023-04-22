using System.Collections;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public bool attack;
    public bool run;

    [Tooltip("type 0 = Idle Citizen\ntype 1 = Panic Citizen\ntype 2 = Panic Sword\ntype 3 = Bow Citizen")]
    public int type;

    public float attackRate;
    public float fireDelay;

    float cooldown;
    
    public GameObject hazard;
    public GameObject zombieToSpawn;

    Animator animator;

    Movement movement;

     void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (run && type == 1)
            Escape();

        if (attack)
            Attack();
        else
            animator.SetBool("Attack", false);
    }

    void FixedUpdate()
    {
        attack = false;
    }

    void Escape()
    {
        if (Time.time >= cooldown)
        {
            animator.SetBool("Panic", true);
            cooldown = Time.time + 1f;
            movement.dir = -movement.dir;
            movement.moveSpeed = movement.moveSpeed + 1;
        }
    }

    void Attack()
    {
        if (Time.time >= cooldown)
        {
            animator.SetBool("Attack", true);

            if(type == 3)
                StartCoroutine(ShowProjectile());

            cooldown = Time.time + 1f / attackRate;
        }
        else if (Time.time <= cooldown)
            animator.SetBool("Attack", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Zombie"))
        {
            Instantiate(zombieToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator ShowProjectile()
    {
        yield return new WaitForSeconds(fireDelay); 
        Instantiate(hazard, transform.position, transform.rotation);
    }
}
