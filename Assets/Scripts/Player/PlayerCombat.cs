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

    private int damage;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            SoundManagerScript.PlaySound("WeaponSwitching");
            Sword = true;
            Whip = false;
            gun = false;
        }
        else if (Input.GetKeyDown("2"))
        {
            SoundManagerScript.PlaySound("WeaponSwitching");
            Sword = false;
            Whip = true;
            gun = false;
        }
        else if (Input.GetKeyDown("3"))
        {
            SoundManagerScript.PlaySound("WeaponSwitching");
            Sword = false;
            Whip = false;
            gun = true;
        }

        // Sword
        if (Time.time >= nextAttackTime && Sword == true) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // attack rate
                nextAttackTime = Time.time + 0.5f / attackRate;

                // Play an attack animation
                animator.SetTrigger("AttackSword");

                // Play Sound
                SoundManagerScript.PlaySound("SwordAttack");

                // Detect enemies in range of attacks
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeSword, enemyLayers);

                // damage them
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(60 + damage);
                }
            }
        }

        //Whip
        if (Time.time >= nextAttackTime && Whip == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // attack rate
                nextAttackTime = Time.time + 1f / attackRate;

                // Play an attack animation
                animator.SetTrigger("AttackWhip");

                // Play Sound
                SoundManagerScript.PlaySound("WhipAttack");

                // Detect enemies in range of attacks
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeWhip, enemyLayers);

                // damage them
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(40 + damage);
                }
            }
        }
        // gun
        if (Time.time >= nextAttackTime && gun == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // attack rate
                nextAttackTime = Time.time + 1f / attackRate;

                // Play Sound
                SoundManagerScript.PlaySound("GunAttack");

                // shooting logic
                BulletPrefab.GetComponent<Bullet>().Damage = damage;

                //Damage = BulletPrefab.GetComponent<Bullet>().Damage;
                Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            }
        }

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
    public int getDamage() { return damage; }
}
