using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tryAgain : MonoBehaviour
{
    public void Start()
    {
        // Enable the cursor to allow user interaction/input
        Cursor.visible = true;

        // Set the cursor lock state to none, allowing it to move freely.
        Cursor.lockState = CursorLockMode.None;
    }

    // Load the game scene for a second attempt.
    public void secondTry()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
