using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controls : MonoBehaviour
{
    //Controls menu, either go back to menu, or play game from there
    //enter scene name for cut scene (on play game)
    public string sceneName;
    
    public GameSounds audio;

    public void backToMenu()
    {  
        SceneManager.LoadSceneAsync(0);
        audio.playSound();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}

