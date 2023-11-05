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
    private bool firstLevel;
    private bool secondLevel;

 

    void Start()
    {
        //get scene name to check for right scene when checking coordinates
        string currentSceneName = SceneManager.GetActiveScene().name;
       
        //set scene booleans for update
        if (currentSceneName == "FirstLevel")
        {
            firstLevel = true;
        }

        else if (currentSceneName == "SecondLevel")
        {
            secondLevel = true;
        }

        //test alert
        showAlert("Welcome.");
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

        //first level coordinates
        if (firstLevel)
        {
             //starting position
             //if starting, on the first level, show an alert with some basic gameplay hints
             if (playerPosition == new Vector3(2.25f, 2.60f, 31.13f))
             {
                 showAlert("Welcome. To progress to the next level, collect all treasure (coins). Press Enter to exit message.");
             }
        }

        if (secondLevel)
        {
            //starting position
             //if starting, on the second level, show an alert with some new basic gameplay hints
             if (playerPosition == new Vector3(2.25f, 2.60f, 31.13f))
             {
                 showAlert("Welcome to level 2 - if you walk into a trap, you will lose a life and respawn (or not), so be careful!"); 
             }
        }
    }
}
