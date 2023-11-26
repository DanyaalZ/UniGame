using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("PLAYGAME");
        SceneManager.LoadSceneAsync(2);
    }

    public void checkControls()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
