﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    private float kracht = 500;
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
        
        //play hurt animation
        animator.SetTrigger("Hurt");

        // knockback effect
        //GetComponent<Rigidbody2D>().AddForce(transform.right * kracht);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Spikes
        if (collision.tag == "Spikes")
        {
            TakeDamage(100);
        }


    }

    void Die()
    {
        // to test if Enemy is dead

        // Die animation
        animator.SetBool("IsDead", true);

        // Disable the enemy
        Destroy(gameObject);
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
    }
}
