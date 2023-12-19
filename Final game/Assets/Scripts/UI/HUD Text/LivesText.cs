using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesText : MonoBehaviour
{
    public TMP_Text healthText;

    //base player lives are 3, these variables are static to maintain among different objects and scenes
    private static int baseLives = 3;   
    //lives increase collected by player as powerups, should remain constant among all scenes
    private static int livesIncrease;
    //to distinguish between base lives and current player lives
    private static int currentLives;

    private void Start()
    {
        //initialise lives for new level
        initializeLives();
    }

    private void initializeLives()
    {
        //add number of powerup lives earned to base lives to get current lives
        currentLives = baseLives + livesIncrease;
        UpdateLivesDisplay();
    }

    //decrement lives by one when players falls off or gets hurt
    public void decrementLives()
    {
        if (currentLives > 1)
        {
            currentLives--;
        }
        //if player reaches 0 lives call game over
        else
        {
            gameOver();
        }
        //update text each time function is called
        UpdateLivesDisplay();
    }

    private void gameOver()
    {
        //Load try again scene when player reaches 0 lives
        SceneManager.LoadScene("TryAgain");
    }

    //for health powerup, increment lives by amount given by powerup when collected (in lifeCollision script)
    public void incrementLives(int amount)
    {
        livesIncrease += amount;
        currentLives += amount;
        UpdateLivesDisplay();
    }

    private void UpdateLivesDisplay()
    {
        //update health text whenever there is a lives update
        healthText.text = $"Lives: {currentLives}";
    }
}
