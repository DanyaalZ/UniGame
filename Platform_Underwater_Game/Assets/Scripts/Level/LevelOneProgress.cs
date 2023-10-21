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
        //if all coins achieved for level one, progress
        if (coinText.text == "Coins: 10" && !completeMessageShown)
        {
            alert.showAlert("Level One complete!");
            completeMessageShown = true;
        }

        //at 3 coins, remind player of objective    
        if (coinText.text == "Coins: 3" && !reminderMessageShown)
        {
            alert.showAlert("Good, remember to collect all coins or you won't progress to the next level.");
            reminderMessageShown = true;
        }
    }
}
