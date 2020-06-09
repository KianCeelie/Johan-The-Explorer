using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinTxt;
    public float coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "coin")
        {
            SoundManagerScript.PlaySound("CoinPickup");
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
