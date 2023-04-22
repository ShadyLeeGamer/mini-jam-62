using UnityEngine;

public class Check : MonoBehaviour
{
    public int type;

    public Movement movement;
    public Citizen citizen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") && type == 1)
            movement.dir = -movement.dir;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground") && type == 0 ||
            other.CompareTag("Wall") && type == 0)
            movement.isGrounded = true;

        if (other.CompareTag("Zombie") && type == 2)
            citizen.run = true;

        if (other.CompareTag("Zombie") && type > 2)
            citizen.attack = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground") && type == 0 ||
            other.CompareTag("Wall") && type == 0)
            movement.isGrounded = false;

        if (other.CompareTag("Zombie") && type == 2)
            citizen.run = false;

        if (other.CompareTag("Zombie") && type > 2)
        {
            citizen.attack = false;
            movement.dir = movement.currentDir;
        }
    }
}
