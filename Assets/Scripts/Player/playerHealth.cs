using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public GameObject GameOverPanel;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public bool HitImmunity = false;

    private float Cooldown = 1f;
    private float CooldownTimer = 0f;

    private bool DamageImmunity = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //test if damage works
        if (Input.GetKeyDown(KeyCode.H) && HitImmunity == false)
        {
            TakeDamage(25);
            DamageImmunity = true;
        }

        // If hit, play This script that makes you immune to damage for 1 second
        if (DamageImmunity == true)
        {
            HitImmunity = true;
            CooldownTimer += Time.deltaTime;

            if (CooldownTimer > Cooldown)
            {
                HitImmunity = false;
                DamageImmunity = false;

                CooldownTimer = CooldownTimer - Cooldown;
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
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
        if (collision.tag == "Enemy" && HitImmunity == false)
        {
            TakeDamage(50);
            DamageImmunity = true;
        }

        // traps

        // Spikes
        if (collision.tag == "Spikes" && HitImmunity == false)
        {
            TakeDamage(100);
            DamageImmunity = true;
        }

        // Fire?
        if (collision.tag == "EnemySpear" && HitImmunity == false)
        {
            TakeDamage(25);
            DamageImmunity = true;
        }
    }

}
