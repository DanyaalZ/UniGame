using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyModes : MonoBehaviour
{
    public static string difficultyMode;
    // Start is called before the first frame update
    void Start()
    {
        difficultyMode = "Normal";
    }

    public void setModeEasy()
    {
        difficultyMode = "Easy";
    }

    public void setModeNormal()
    {
        difficultyMode = "Normal";
    }

    public void setModeHard()
    {
        difficultyMode = "Hard";
    }
}
