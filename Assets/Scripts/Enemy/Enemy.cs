using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
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
