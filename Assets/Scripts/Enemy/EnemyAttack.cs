using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;

    [SerializeField]
    Transform player;

    //de range dat de enemy boos wordt

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    private LayerMask WhatIsGround;
    
    [SerializeField] 
    private Transform m_GroundCheck;

    private bool IsGrounded;

    const float k_GroundedRadius = 0.2f;

    bool isFacingLeft;

    Rigidbody2D rb2d;

    private bool isAgro = false;

    private bool isSearching;

    public UnityEvent OnLandEvent;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;
        IsGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                IsGrounded = true;
                if (wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            //agro enemy
            isAgro = true;
            
        }
        else
        {
            if (isAgro)
            {
                
                if (!isSearching)
                {
                    isSearching = true;
                    Invoke("StopChasingPlayer", 3);
                }
                
            }
            
        }
        if (isAgro && IsGrounded)
        {
            ChasePlayer();
        }


    }

    
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }

            Debug.DrawLine(castPoint.position, hit.point, Color.yellow);


        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }

        return val;
    }


    void ChasePlayer()
    {
      if(transform.position.x < player.position.x && IsGrounded)
        {
            //enemy is to the left site of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(5, 5);
            isFacingLeft = false;
        }
        else 
        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-5, 5);
            isFacingLeft = true;
        }

    }

    void StopChasingPlayer()
    {
        //kan ook schrijven new vector2(0,0); stopt alle movement
        isSearching = false;
        IsGrounded = false;
        rb2d.velocity = Vector2.zero;

    }
}
