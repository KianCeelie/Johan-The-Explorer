using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(25);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            switchscenes();
        }
    }

    void switchscenes()
    {
        SceneManager.LoadScene(4);
    }

   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "health")
        {
            maxHealth = 125;
            currentHealth = 125;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "DamagePowerup")
        {

        }
        // Enemies

        // Normal Enemy
        if (collision.tag == "Enemy")
        {
            TakeDamage(25);
        }

        // traps

        // Spikes
        if (collision.tag == "Spikes")
        {
            TakeDamage(100);
        }

        // Fire?

    }

    
}
