using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerData : MonoBehaviour
{
    public float health = 100f;

    public Text coinTxt;
    public float coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            coins += 1f;
            coinTxt.text = coins.ToString();
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        coinTxt.text = coins.ToString();
    }
}
