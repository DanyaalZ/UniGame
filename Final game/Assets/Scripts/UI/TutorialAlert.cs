using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for NPC tutorial (collision with droids) - when you collide with a droid as the player the alert window canvas is set to
visible, and text is displayed */

public class TutorialAlert : MonoBehaviour
{
    public AlertWindow alert;

    public GameSounds gameSounds;

    //text to show, initialised in the inspector for each different droid
    public string tutorialText;

    private void OnCollisionEnter(Collision collision)
    {
        //play droid sound on collision (initialised in object)
        gameSounds.playSound();
        alert.showAlert(tutorialText);
    }
}
