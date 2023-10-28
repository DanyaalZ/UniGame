using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesText : MonoBehaviour
{
    public TMP_Text healthText;
    public int lives = 3;

    public void OnStart()
    {
        resetLives();
    }

    //decrement lives text where needed e.g. falling off, hitting enemy
    public void decrementLives()
    {
        if (lives > 0)
        {
            lives--;
            healthText.text = $"Lives: {lives}";
        }
    }

    //reset lives to a default of 3
    public void resetLives()
    {
        lives = 3;
        healthText.text = $"Lives: {lives}";
    }
}
