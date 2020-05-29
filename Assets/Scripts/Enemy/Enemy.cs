using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    public int Health = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // to test if Enemy is dead
        //Debug.Log("Enemy Died");

        // Die animation
        animator.SetBool("IsDead", true);

        // Disable the enemy
        Destroy(gameObject);
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
    }
}
