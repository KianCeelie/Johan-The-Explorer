using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Destroy(gameObject);
    }


}
