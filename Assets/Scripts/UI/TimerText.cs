using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timerText : MonoBehaviour
{
    //variable time text
    public TMP_Text timer;

    //time left in seconds, defaulted to normal difficulty
    private float timeRemainingSeconds = 120;

    private bool timerRunning = false;


    //timer - if player runs out of time they lose the game

    public void Start()
    {
        //start the timer automatically, set time based on level of difficulty
        timerRunning = true;
        setDifficultyTime();
    }

    //set time remaining based on difficulty mode
    private float setDifficultyTime()
    {
        //easy mode - 5 minute timer
        if (DifficultyModes.difficultyMode == "Easy"){
            timeRemainingSeconds = 300;
        }

        //normal mode - 2 minute timer
        else if (DifficultyModes.difficultyMode == "Normal"){
            timeRemainingSeconds = 120;
        }

        //hard mode - 1 minute timer
        else if (DifficultyModes.difficultyMode == "Hard"){
            timeRemainingSeconds = 60;
        }
        
        //veteran mode - 30 second timer
        else if (DifficultyModes.difficultyMode == "Veteran"){
            timeRemainingSeconds = 30;
        }

        return timeRemainingSeconds;
    }

    private void Update()
    {
        if (timerRunning)
        {
            //if timer is running, and time not up, use real time to take away from remaining time
            if (timeRemainingSeconds > 0)
            {
                timeRemainingSeconds -= Time.deltaTime;
                displayTheTime(timeRemainingSeconds);
            }
            else
            {
                //if it's over, disable timer, display game over as player has ran out of time to complete level
                timeRemainingSeconds = 0;
                timerRunning = false;
            }
        }

        else if (timeRemainingSeconds == 0)
        {
            SceneManager.LoadScene("TryAgain");
        }
    }

    private void displayTheTime(float displayTime)
    {
        if(displayTime < 0)
        {
            displayTime = 0;
        }

        //convert minutes, seconds for display by timer, remainder will be seconds
        float minutes = Mathf.FloorToInt(displayTime / 60);  
        float seconds = Mathf.FloorToInt(displayTime % 60);

        //display time
        if (timer != null) 
        {
            timer.text = ("Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds));
        }
    }
}

  