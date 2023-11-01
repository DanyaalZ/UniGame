using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameend : MonoBehaviour
{
    public string scenename;

    //for checking amount of coins before progressing
    public TMP_Text coinText;
    public AlertWindow alert;
    
    //if player collected 20 coins, allow portal to progress 
    //otherwise tell player to collect more
    void checkIfPlayerCollectedCoins()
    {
        //if all coins achieved for level two, end game
        if (coinText.text == "Coins: 20")
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