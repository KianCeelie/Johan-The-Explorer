using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrap : MonoBehaviour
{

    public Transform FirePointTrap;
    public GameObject BulletPrefab;

    public float FireRate = 1f;
    float nextAttackTime = 0f;
    bool Gun = true;
    private void Start()
    {

    }

    void Update()
    {
        if (Time.time >= nextAttackTime && Gun == true)
        {
            {
                // attack rate
                nextAttackTime = Time.time + 1f / FireRate;

                // Play Sound
                SoundManagerScript.PlaySound("GunAttack");

                //Damage = BulletPrefab.GetComponent<Bullet>().Damage;
                Instantiate(BulletPrefab, FirePointTrap.position, FirePointTrap.rotation);
            }
        }
    }
}
