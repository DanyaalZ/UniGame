using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class tryAgain : MonoBehaviour
{
    public void Start()
    {
        //allow user to click by reenabling cursor
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called before the first frame update
    public void secondTry()
    {
        SceneManager.LoadSceneAsync(2);
    }

}
