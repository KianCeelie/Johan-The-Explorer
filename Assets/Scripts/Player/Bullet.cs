using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Damage;


    public Bullet(int Damage) { }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;       
    }

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        EnemyHealth enemy = HitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(60 + Damage);
        }
        Destroy(gameObject);
    }


}
