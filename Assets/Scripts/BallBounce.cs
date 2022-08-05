using System;
using UnityEngine;

public class BallBounce : MonoBehaviour
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
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            var direction = Vector2.Reflect(lastVelocity, col.contacts[0].normal);
            rb.velocity = direction;
        }
        else if (col.gameObject.CompareTag("Block"))
        {
            var direction = Vector2.Reflect(lastVelocity, col.contacts[0].normal);
            rb.velocity = direction;
            col.gameObject.GetComponent<Blocks>().UpdateBlockHealth();
        }
        
    }
    
}
