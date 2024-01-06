using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AlertWindow : MonoBehaviour
{
    //to set visible, not visible
    public GameObject alertWindow;

    public TMP_Text alertWindowText;

    //get player game object for coordinates
    public Transform playerTransform;


    //to check which scene currently in
    private bool tutorialLevel;
    private bool firstLevel;
    private bool secondLevel;

    private bool thirdLevel;

    private bool finalLevel;
 

    void Start()
    {
        //get scene name to check for right scene when checking coordinates
        string currentSceneName = SceneManager.GetActiveScene().name;

        //set scene booleans for update

        if (currentSceneName == "Tutorial")
        {
            tutorialLevel = true;
        }

        if (currentSceneName == "FirstLevel")
        {
            firstLevel = true;
        }

        else if (currentSceneName == "SecondLevel")
        {
            secondLevel = true;
        }
        
        //show tutorial alerts for level three and four - these will not use coordinates
        if (currentSceneName == "ThirdLevel")
        {
            thirdLevel = true;
            showAlert("Captain, there will be some attacking enemies, get to the next level! Click E to see inventory. Press 1 - SMG, 2 - Shotty, 3 - AR, 4 - Melee. Click to attack.");
        }

        if (currentSceneName == "FinalLevel")
        {
            finalLevel = true;
            showAlert("Captain, escape and get to the treasure! You do not need to defeat the enemies but it will help, and you must defeat the big boss...");
        }
    }

    //show alert at particular location with particular text
    public void showAlert(string text)
    {
        //update text
        alertWindowText.text = text;

        //set visible
        alertWindow.SetActive(true);
    }
    

    void Update()
    {
        //get player coordinates
        Vector3 playerPosition = playerTransform.position;

        //at fixed coordinates, alerts will be shown (for particular scene)

        //starting coordinates

        if (tutorialLevel)
        {
            if (playerPosition == new Vector3(2.25f, 2.60f, 31.13f))
            {
                 showAlert("Welcome captain, here's a refresher: Use WASD to move, and the mouse to look around. The green cubes will be your guide from here, so walk into them!");
            }
        }

        if (firstLevel)
        {
             //starting position
             //if starting, on the first level, show an alert with some basic gameplay hints
             if (playerPosition == new Vector3(2.25f, 2.66f, 31.13f))
             {
                 showAlert("Welcome. To progress to the next level, collect all treasure (coins). Press Enter to exit message.");
             }
        }

        if (secondLevel)
        {
            //starting position
             //if starting, on the second level, show an alert with some new basic gameplay hints
             if (playerPosition == new Vector3(2.25f, 2.66f, 31.13f))
             {
                 showAlert("Welcome to level 2 - if you walk into a trap, you will lose a life and respawn (or not), so be careful!"); 
             }
        }
    }
}
