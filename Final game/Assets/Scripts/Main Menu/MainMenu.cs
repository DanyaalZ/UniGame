using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main menu - holding different menus, play sounds when buttons clicked (UI sounds)
public class MainMenu : MonoBehaviour
{
    //get name of scene (in this case will be cut scene 1)
    public string sceneName;

    public GameSounds gameSounds;

    public void Start()
    {
        //enable the cursor incase user coming from scene where it was not
        Cursor.visible = true;

        //as above
        Cursor.lockState = CursorLockMode.None;
    }

    //when play glame is clicked, load cut scene 1, which will in turn get to the game
    //scenename referenced above
    public void PlayGame()
    {
        gameSounds.playSound();
        SceneManager.LoadScene(sceneName);
    }

    //load tutorial
    public void PlayTutorial()
    {
        gameSounds.playSound();
        SceneManager.LoadScene("Tutorial");
    }

    //difficulty settings
    public void DifficultySettings()
    {
        SceneManager.LoadScene("Difficulty");
    }

    //check controls
    public void checkControls()
    {
        SceneManager.LoadSceneAsync(1);
    }

    //saved high scores
    public void highScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    //input sensitivity and volume settings
    public void realSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
