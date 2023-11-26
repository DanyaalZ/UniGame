using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Difficulty settings are changed in TimerText.cs, and
// ^ based on difficulty set here
public class DifficultyModes : MonoBehaviour
{
    //static so it remains constant through the game
    public static string difficultyMode;
  
    void Start()
    {
        //if not set leave it at normal
        if (difficultyMode == null)
        {
            difficultyMode = "Normal";
        }
    }

    //set easy
    public void setModeEasy()
    {
        difficultyMode = "Easy";
    }

    //set normal
    public void setModeNormal()
    {
        difficultyMode = "Normal";
    }

    //set hard
    public void setModeHard()
    {
        difficultyMode = "Hard";
    }

    //set veteran
    public void setModeVeteran()
    {
        difficultyMode = "Veteran";
    }
}
