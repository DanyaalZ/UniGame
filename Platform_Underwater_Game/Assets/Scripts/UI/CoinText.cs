using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinText : MonoBehaviour
{
    //initialise to 0 coins - static means it keeps track of the variable in all instances
    public static int coinAmount = 0;

    //variable coin text
    public TMP_Text coin;

    public void OnStart()
    {
        //Initially set coins to 0
        coin.text = "Coins: 0";
    }
    public void updateText(int amount)
    {
        //increase coins by specified amount, update text
        coinAmount += amount;
        coin.text = ($"Coins: {coinAmount}");

    }
}
