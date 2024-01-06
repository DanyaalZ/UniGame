using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//When a player goes back to menu, their scores are saved if they are high scores
public class backToMenuSave : MonoBehaviour
{    
    public SaveData saveData;
    void Start()
    {
      
    }

    public void backToMenuandSave()
    {
        //save data (which will depend on whether high score is met in classes, and go back to main menu)
        saveData.SaveGame();
        SceneManager.LoadScene("MainMenu");
    }
}
