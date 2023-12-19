using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinText : MonoBehaviour
{
    //static means it keeps track of the variable in all instances
    public static int coinAmount;

    //variable coin text
    public TMP_Text coin;

    //sometimes user gets first coin in first level coming from other levels, and it messes up, so this is a reset
    public void resetCoins()
    {
        coinAmount = 0;
    }

    public int getCoinAmount()
    {
        Debug.Log(coinAmount);
        return coinAmount;
    }
    
    public void updateText(int amount)
    {
        //increase coins by specified amount, update text
        coinAmount += amount;
        coin.text = ($"Coins: {coinAmount}");

    }
}
