using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f; // Speed of the bullet
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component
        rb.velocity = Vector2.up * speed;  // Move the bullet up
        Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
