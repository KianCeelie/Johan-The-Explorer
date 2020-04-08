using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpValue;
   
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    private int extraJumps;
    private bool dubbleJumpIsActive = false;

    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dubbleJumpIsActive == true)
        {
            if (isGrounded == true)
            {
                extraJumps = extraJumpValue;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && jumpForce == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "jump")
        {
            Destroy(collision.gameObject);
            dubbleJumpIsActive = true;
        }

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }


    void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }

