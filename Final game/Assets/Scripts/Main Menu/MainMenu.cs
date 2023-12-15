using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //get name of scene (in this case will be cut scene 1)
    public string sceneName;

    public void Start()
    {
        // Enable the cursor to allow user interaction.
        Cursor.visible = true;

        // Set the cursor lock state to none, allowing it to move freely.
        Cursor.lockState = CursorLockMode.None;
    }

    //When play glame is clicked, load cut scene 1, which will in turn get to the game
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void DifficultySettings()
    {
        SceneManager.LoadScene("Difficulty");
    }

    //check controls
    public void checkControls()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void highScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
