using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //get name of scene (in this case will be cut scene 1)
    public string sceneName;
    // Start is called before the first frame update

    //When play glame is clicked, load cut scene 1, which will in turn get to the game
    public void PlayGame()
    {
        Debug.Log("PLAYGAME");
        SceneManager.LoadScene(sceneName);
    }

    //check controls
    public void checkControls()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
