using UnityEngine;


public class BallController : MonoBehaviour
{
    public SpriteRenderer _renderer;
    
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        DestroyBall();
        lastVelocity = (rb.velocity * 9) / 10;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            var direction = Vector2.Reflect(lastVelocity, col.contacts[0].normal);
            rb.velocity = direction;
            Debug.Log(rb.velocity.magnitude);
        }
        else if (col.gameObject.CompareTag("Block"))
        {
            var direction = Vector2.Reflect(lastVelocity, col.contacts[0].normal);
            rb.velocity = direction;
            col.gameObject.GetComponent<Block>().UpdateBlockHealth();
        }
    }

    void DestroyBall()
    {
        if (BlockSpawner.Instance.wholeSetDestroyed)
        {
            Destroy(gameObject);
        }
    }
    
    
}
