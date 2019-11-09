using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Properties
    Rigidbody2D rbody;

    //Movement
    public float speed;
    public float jumpForce;
    float moveVelocity;

    //Grounded Vars
    bool grounded = true;

    void Start () 
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput () 
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (checkGrounded())
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            }
        }

        //Left Right Movement
        moveVelocity = 0;
        moveVelocity = Input.GetAxis("Horizontal") * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
        
    //Check if Grounded - ripped from DioTheHero - Harrold
    private bool checkGrounded() {
        float distToGround = GetComponent<Collider2D>().bounds.extents.y;
        RaycastHit2D collision = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 
            distToGround + 0.1f, 
            LayerMask.GetMask("Ground")
        );

        return (collision.collider != null);
    }
}