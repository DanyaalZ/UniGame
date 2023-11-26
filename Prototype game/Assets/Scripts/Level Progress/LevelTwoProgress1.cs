using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTwoProgress : MonoBehaviour
{
    public TMP_Text coinText;
    public AlertWindow alert;
    private bool reminderMessageShown = false; 

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //at 20 coins, remind player to enter portal to finish   
        if (coinText.text == "Coins: 20" && !reminderMessageShown)
        {
            alert.showAlert("Good job - enter the portal to end the game!");
            reminderMessageShown = true;
        }
    }
}
