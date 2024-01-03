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

    // Flags to track if weapons have been bought
    private bool hasBoughtSMG = false;
    private bool hasBoughtShotty = false;
    private bool hasBoughtAR = false;


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

    //buy weapons and cannot purchase the same type more than once because of flags
    public void buySMG()
    {
        //remove amount from coins, allow it to be displayed as text
        if (!hasBoughtSMG && checkCoins(10))
        {
            coins.shopping(10);
            coinAmount -= 10;
            gunInventory.addGun("SMG");
            hasBoughtSMG = true; 
        }
    }

    public void buyShotty()
    {
        //remove amount from coins, allow it to be displayed as text
        if (!hasBoughtShotty && checkCoins(15))
        {
            coins.shopping(15);
            coinAmount -= 15;
            gunInventory.addGun("Shotty");
            hasBoughtShotty = true; 
        }
    }

    public void buyAR()
    {
        //remove amount from coins, allow it to be displayed as text
        if (!hasBoughtAR && checkCoins(10))
        {
            coins.shopping(10);
            coinAmount -= 10;
            gunInventory.addGun("AR");
            hasBoughtAR = true; 
        }
    }

}