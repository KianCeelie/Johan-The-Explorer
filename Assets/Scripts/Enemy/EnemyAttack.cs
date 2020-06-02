using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    bool isFacingLeft;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            //agro enemy
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
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

        Vector2 endPos = castPoint.position + Vector3.right * castDist;

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
      if(transform.position.x < player.position.x)
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
        //kan ook schriven new vector2(0,0); stopt alle movement
        rb2d.velocity = Vector2.zero;

    }
}
