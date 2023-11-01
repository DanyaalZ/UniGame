using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTwoProgress : MonoBehaviour
{
    public TMP_Text coinText;
    public AlertWindow alert;

    private bool levelMessageShown = false;
    private bool reminderMessageShown = false; 

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tell player they are on level 2 when they collect a coin
        if (coinText.text == "Coins: 11" && !levelMessageShown)
        {
            alert.showAlert("This is level 2 - things will start to get harder.");
            levelMessageShown = true;
        }

        //at 20 coins, remind player to enter portal to finish   
        if (coinText.text == "Coins: 20" && !reminderMessageShown)
        {
            alert.showAlert("Good job - enter the portal to end the game!");
            reminderMessageShown = true;
        }
    }
}
