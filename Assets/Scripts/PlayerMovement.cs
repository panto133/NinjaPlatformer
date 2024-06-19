using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpDistance = 5f;
    [SerializeField]
    private LayerMask ground;

    private Transform legs;
    private bool onGround = true;
    private bool doubleJump = true;
    private Rigidbody2D rb;

    private void Start()
    {
        legs = transform.GetChild(0).transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        onGround = Physics2D.OverlapCircle(legs.position, .6f, ground);
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                doubleJump = true;
                return;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpDistance);
                doubleJump = false;
            }
            
        }
        
    }
}
