using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* Script for ending level 3 and 4 based on certain parameters (based around enemies, warranting this separate script) */
public class levelthreefourend : MonoBehaviour
{  
    //the scene the player will be sent to at the end of a level
    public string sceneName;

    //to get number of enemies for level 3
    public Enemies enemy;

    public AlertWindow alert;

    //to check if big boss is defeated before getting final treasure and ending game on level 4
    private GameObject bigBoss; 

    //to get scene we are in
    private string currentSceneName;

    void Start()
    {
        //get current scene name
        currentSceneName = SceneManager.GetActiveScene().name;

       
        if (currentSceneName == "FinalLevel")
        {
            bigBoss = GameObject.FindWithTag("Big Boss");  
        }
    }

    void Update()
    {
        //regularly check if big boss is still in level for level 4
        if (currentSceneName == "FinalLevel")
        {
            bigBoss = GameObject.FindWithTag("Big Boss");
        }
    }


    //end of level three and four, which do not require coins so get a different script
    //for level 3 player needs to defeat at least a few enemies meaning there should be less than 5 left
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentSceneName == "ThirdLevel" && enemy.enemyCount < 5) 
            {
                //this will load level 4 cutscene, input in inspector
                SceneManager.LoadScene(sceneName);
            }

            //player unable to go to next level yet
            else if (currentSceneName == "ThirdLevel" && enemy.enemyCount >= 5)
            {
                alert.showAlert("You need to defeat at least a few enemies to progress! On the next level this will not be necessary.");
            }
            
            //final level - big boss must be defeated (null gameobject)
            else if (currentSceneName == "FinalLevel" && bigBoss == null)
            {
                 //this will load the ending cutscene to the game
                 SceneManager.LoadScene(sceneName);
            }

            //big boss not defeated (final level)
            else if (currentSceneName == "FinalLevel" && bigBoss != null)
            {
                alert.showAlert("I don't know how you managed to sneak past the big boss but you must defeat him to continue...");
            }
        }
    }
}