using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nextscene : MonoBehaviour
{
    public string sceneName;

    //for checking amount of coins before progressing
    public TMP_Text coinText;
    public AlertWindow alert;

    
    //if player collected 10 coins, allow portal to progress 
    //otherwise tell player to collect coins
    void checkIfPlayerCollectedCoins()
    {
        //if all coins achieved for level one, progress
        if (coinText.text == "Coins: 10")
        {
            SceneManager.LoadScene(sceneName);
        }

        else
        {
            alert.showAlert("You need to collect more coins first!");
        }
    }

    //run above method if touching portal
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkIfPlayerCollectedCoins();
        }
    }
}