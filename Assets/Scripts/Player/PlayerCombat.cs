using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    // Sword
    public float attackRangeSword = 0.5f;

    // Whip
    public float attackRangeWhip = 1f;

    //gun
    public Transform FirePoint;
    public GameObject BulletPrefab;

    bool Sword = true;
    bool Whip = false;
    bool gun = true;

    private int Damage;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            Sword = true;
            Whip = false;
            gun = false;
        }
        else if (Input.GetKeyDown("2"))
        {
            Sword = false;
            Whip = true;
            gun = false;
        }
        else if (Input.GetKeyDown("3"))
        {
            Sword = false;
            Whip = false;
            gun = true;
        }

        // Sword
        if (Time.time >= nextAttackTime && Sword == true) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackSword();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        //Whip
        if (Time.time >= nextAttackTime && Whip == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackWhip();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        // gun
        if (Time.time >= nextAttackTime && gun == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    // Weapons

    // Sword
    void AttackSword()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attacks
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeSword, enemyLayers);

        // damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(Damage = 50);
        }
    }

    //Whip
    void AttackWhip()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attacks
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeWhip, enemyLayers);

        // damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(Damage = 40);
        }
    }

    //gun
    void Shoot()
    {
        // shooting logic
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        // sword
        if (Sword == true)
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRangeSword);
        }
        // whip
        else if (Whip == true)
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRangeWhip);
        }
    }
}
