using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public void start()
{

}


public class Controls : MonoBehaviour
{
    //Controls menu, either go back to menu, or play game from there
    //enter scene name for cut scene (on play game)
    public string sceneName;

    //static means it keeps track of the variable in all instances
    public static int coinAmount;

    //variable coin text
    public TMP_Text coin;

    public void backToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }


    public int getCoinAmount()
    {
        Debug.Log(coinAmount);
        return coinAmount;
    }
    public void shopping(int amount)
    {
        coinAmount -= amount;
        coin.text = ($"Coins: {coinAmount}");
    }
}

