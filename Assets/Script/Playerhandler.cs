using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // 
    public float moveSpeed = 5f; // since it is a public, i can edit this value in the unity editor
    public GameObject bulletPrefab; // this is the bullet prefab that we will shoot
    public Transform bulletSpawnPoint; // this is the point where the bullet will spawn
    private Rigidbody2D rb; // this is the rigidbody of the player object
    private float minX, maxX; // Boundaries

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Get screen edges in world space
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // Account for object width to prevent clipping
        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        minX = leftEdge.x + halfWidth;
        maxX = rightEdge.x - halfWidth;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Prevent the player from moving out of bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject instantiate_object = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        instantiate_object.transform.SetParent(bulletSpawnPoint);
        instantiate_object.transform.localScale = new Vector2(1, 1);
    }
}
