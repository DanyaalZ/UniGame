using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class tryAgain : MonoBehaviour
{
    // Start is called before the first frame update
    public void secondTry()
    {
        SceneManager.LoadSceneAsync(2);
    }

}
