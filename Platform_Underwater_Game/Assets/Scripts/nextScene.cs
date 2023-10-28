using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nextscene : MonoBehaviour
{
    public string scenename;
    private bool coinsCollected;

    //for checking amount of coins before progressing
    public TMP_Text coinText;
    public AlertWindow alert;

    
    void OnStart()    
    {
  

    }
    
    //if player collected 10 coins, allow portal to progress 
    //otherwise hide
    void checkIfPlayerCollectedCoins()
    {
        //if all coins achieved for level one, progress
        if (coinText.text == "Coins: 10")
        {
            SceneManager.LoadScene(scenename);
        }

        else
        {
            alert.showAlert("You need to collect more coins first!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkIfPlayerCollectedCoins();
        }
    }
}