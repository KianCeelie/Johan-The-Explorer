using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealthtest : MonoBehaviour
{
    public float health = 100f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "health")
        {
            Destroy(collision.gameObject);
            health = 125f;
        }
        
    }
}
