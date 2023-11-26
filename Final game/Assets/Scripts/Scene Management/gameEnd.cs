using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameend : MonoBehaviour
{
    //for checking amount of coins before progressing
    public TMP_Text coinText;
    public AlertWindow alert;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if all coins achieved for level two, end game
            if (coinText.text == "Coins: 20")
            {
                SceneManager.LoadScene("MainMenu");
            }

            else
            {
                alert.showAlert("You need to collect more coins first!");
            }
        }
    }
}