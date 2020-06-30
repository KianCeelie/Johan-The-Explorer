using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string itemName;
    public float itemCost;
    public string itemDesc;
    public float inStock;
    public float i = 0;

    public CoinsScript coins; 

    public void Health()
    {
        itemName = "Levens";
        itemCost = 10;
        inStock = 1;
        Buy();
    }

    public void Buy()
    {
        if (i < inStock && coins.coinsAantal == itemCost)
        {
            Debug.Log("Bedankt voor het kopen van " + itemName + ".");
            coins.coinsAantal -= itemCost;
            coins.coinTxt.text = coins.coinsAantal.ToString();
            i++;
        }
        else if (i < inStock && coins.coinsAantal != itemCost)
        {
            Debug.Log("Je hebt te weinig geld voor " + itemName + "!");
        }
        else if (i >= inStock && coins.coinsAantal == itemCost)
        {
            Debug.Log(itemName + " is uitverkocht");
        }
        else if (i >= inStock && coins.coinsAantal != itemCost)
        {
            Debug.Log(itemName + " is uitverkocht");
        }
    }
}
