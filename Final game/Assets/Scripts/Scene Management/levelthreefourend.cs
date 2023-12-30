using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelthreefourend : MonoBehaviour
{
    public string sceneName;
    
    //end of level three and four, which do not require coins so get a different script
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
       
        }
    }
}