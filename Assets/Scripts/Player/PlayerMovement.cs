using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    bool jump = false;
    bool crouch = false;


    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumpValue;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int extraJumps;
    private bool dubbleJumpIsActive = false;

    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (dubbleJumpIsActive == true)
        {
            if (isGrounded == true)
            {
                extraJumps = extraJumpValue;
            }

            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("IsJumping", true);
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.W) && jumpForce == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)

            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
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

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        // move our character, beweeg ons karakter
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
}
