using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") ||
            other.CompareTag("Zombie"))
            Destroy(gameObject);
    }
}
