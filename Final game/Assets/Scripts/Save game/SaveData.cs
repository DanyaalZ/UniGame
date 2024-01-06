using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//save data to json db, called if player gets a high score on all three values (called in other classes such as gameover, game end)
public class SaveData : MonoBehaviour
{   
    //get handle data class to deal with data
    public HandleData handleData;

    //current data to store
    public PlayerData data;

    //to get current coin amount to store
    public coinText coin;

    //to get current time left (seconds)
    public timerText timer;

    void Start()
    {
        //check if we are auto saving (happens in cutscene 3_1, 3_2 after level 2)
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "CutScene3_1" || currentSceneName == "CutScene3_2")
        {
            SaveGame();
        }
   }

    //to use for high score data, level name is parsed into function
    public void SaveGame()
    {
        data.setCoinAmount(coin.getCoinAmount());
        data.setTimeAmount(timer.timeRemainingSeconds);
        handleData.saveData(data);
    }
}
