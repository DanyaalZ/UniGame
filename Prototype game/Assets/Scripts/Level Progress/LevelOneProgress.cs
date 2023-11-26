using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelOneProgress : MonoBehaviour
{
    public TMP_Text coinText;
    public AlertWindow alert;

    private bool completeMessageShown = false;
    private bool reminderMessageShown = false; 

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if all coins achieved for level one, progress message shown
        if (coinText.text == "Coins: 10" && !completeMessageShown)
        {
            alert.showAlert("Level One complete! Enter the portal to continue.");
            completeMessageShown = true;
        }

        //at 3 coins, remind player of objective    
        if (coinText.text == "Coins: 3" && !reminderMessageShown)
        {
            alert.showAlert("Good, remember to collect all coins or you won't progress to the next level.");
            reminderMessageShown = true;
        }

         //if trying again from level 2 reset coins to what they should be
         //get int from coins and then replace
        string coinsString = coinText.text.Replace("Coins: ", "").Trim();

        //parse into string
        if (int.TryParse(coinsString, out int currentCoins) && currentCoins > 11)
        {
            //reset the number of coins to 1 as this will change when player collects first coin
            coinText.text = "Coins: 1";
        }
    }
}
