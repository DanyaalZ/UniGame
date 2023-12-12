using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesText : MonoBehaviour
{
    public TMP_Text healthText;
    public int lives = 3;

    public void OnStart()
    {
        resetLives();
    }

    // Decrement lives and handle game over scenario
    public void decrementLives()
    {
        if (lives > 0)
        {
            lives--;
            healthText.text = $"Lives: {lives}";
        }
        else
        {
            // Handle game over scenario, e.g., reload the scene or show game over screen
            Debug.Log("Game Over");
            SceneManager.LoadSceneAsync(4); // Reload current scene
        }
    }

    //reset lives to a default of 3
    public void resetLives()
    {
        lives = 3;
        healthText.text = $"Lives: {lives}";
    }

}


