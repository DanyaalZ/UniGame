using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAlert : MonoBehaviour
{
    public AlertWindow alert;

    public string tutorialText;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        alert.showAlert(tutorialText);
    }
}
