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
    public float slideSlow;
    private bool isSliding;
    private bool isFacingRight;

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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (checkGrounded())
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            }
        }

        // init sliding motion
        if (Input.GetKey(KeyCode.Space) && !isSliding) {
            EnterSlide();
        }
        if (Input.GetKeyUp(KeyCode.Space) && isSliding) {
            ExitSlide();
        }

        //Left Right Movement / sliding
        moveVelocity = Input.GetAxis("Horizontal") * speed;
        isFacingRight = (moveVelocity > 0 ? true : false); // where else to update this??

        // move or slide
        if (isSliding) {
            int dir = (isFacingRight ? 1 : -1);
            rbody.velocity = new Vector2(rbody.velocity.x - slideSlow * Time.deltaTime * dir, rbody.velocity.y);
        } else {
            rbody.velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
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

    void EnterSlide () {
        isSliding = true;

        //collider
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.size = new Vector2(col.size.x, col.size.y * 0.5f);

        // speed boost
        rbody.velocity = new Vector2(rbody.velocity.x * 1.2f, rbody.velocity.y);
    }

    void ExitSlide () {
        isSliding = false;

        //collider
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.size = new Vector2(col.size.x, col.size.y * 2f);
    }
}

/*
    slide:
        on activate:
            initial speed boost
            cannot accelerate
            slowly come to a stop
            shrink hitbox
*/