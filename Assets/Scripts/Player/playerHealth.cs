using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public GameObject GameOverPanel;

    public int maxHealth = 100;
    public int healthbuff = 25;
    public int currentHealth;

    public HealthBar healthBar;
    public bool HitImmunity = false;

    private float Cooldown = 1.5f;
    private float CooldownTimer = 0f;

    private bool DamageImmunity = false;

    public int Damage;
    public playerHealth(int Damage) { }

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

        // Roept TimeStop script op
        gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.01f);
        SoundManagerScript.PlaySound("PlayerHitSound");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "health")
        {
            currentHealth += 50;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "DamagePowerup")
        {
            Destroy(collision.gameObject);
            Damage += 50;
        }
        // Enemies

        // Normal Enemy
        if (collision.tag == "Enemy" && HitImmunity == false)
        {
            TakeDamage(25);
            DamageImmunity = true;
        }

        // traps

        // Spikes
        if (collision.tag == "Spikes" && HitImmunity == false)
        {
            TakeDamage(50);
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
