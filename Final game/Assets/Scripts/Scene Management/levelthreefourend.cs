using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelthreefourend : MonoBehaviour
{
    public string sceneName;

    //to get number of enemies for level 3
    public Enemies enemy;

    public AlertWindow alert;

    void Start()
    {
        Debug.Log(enemy.enemyCount);
    }


    //end of level three and four, which do not require coins so get a different script
    //for level 3 player needs to defeat at least a few enemies meaning there should be less than 5 left
    void OnTriggerEnter(Collider other)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (other.CompareTag("Player"))
        {
            if (currentSceneName == "ThirdLevel" && enemy.enemyCount < 5) 
            {
                SceneManager.LoadScene(sceneName);
            }

            else if (currentSceneName == "ThirdLevel" && enemy.enemyCount >= 5)
            {
                alert.showAlert("You need to defeat at least a few enemies to progress! On the next level this will not be necessary.");
            }
            
            else if (currentSceneName == "FinalLevel")
            {
                 SceneManager.LoadScene(sceneName);
            }
        }
    }
}