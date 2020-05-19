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
        Debug.Log(Damage);
        Enemy enemy = HitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }


}
