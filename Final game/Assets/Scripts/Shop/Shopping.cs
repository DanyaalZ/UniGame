using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Shopping : MonoBehaviour
{
    //Go back to game when done, level will go here
    public string levelName;

    //to get and edit coin values
    public coinText coins;

    //inventory values
    public GunInventory gunInventory;

    private int coinAmount;

    //to display coins user has
    public TMP_Text coin;

   
    void Start()
    {
        //enable the cursor incase user coming from scene where it was not
        Cursor.visible = true;

        //as above
        Cursor.lockState = CursorLockMode.None;

        //get coin amount to display from static variable in coin object
        coinAmount = coins.getCoinAmount();

        //display coins
        coin.text = $"Coins: {coinAmount}";
    }

    //go back to game when done with shop, load next level
    public void BackToGame()
    {
        SceneManager.LoadScene(levelName);
    }

    //check if player has enough coins
    private bool checkCoins(int amountNeeded)
    {
        if (coinAmount >= amountNeeded)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //buy items
    public void buySMG()
    {
        if (checkCoins(10))
        {
            //remove amount from coins, allow it to be displayed as text
            coins.shopping(10);
            coinAmount -=10;
            //add item to player inventory
            gunInventory.addGun("SMG");
        }
    }
    
    public void buyShotty()
    {
        if(checkCoins(15))
        {
            //remove amount from coins, allow it to be displayed as text
            coins.shopping(15);
            coinAmount -=15;
            //add item to player inventory
            gunInventory.addGun("Shotty");
        }
    }
    
    public void buyAR()
    {
        if(checkCoins(10))
        {
            //remove amount from coins, allow it to be displayed as text
            coins.shopping(10);
            coinAmount -=10;
            //add item to player inventory
            gunInventory.addGun("AR");
        }
    }
    
}