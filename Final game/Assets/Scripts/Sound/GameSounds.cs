using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
  /*
  This handles all the sounds in the game, and other scripts will use it when a sound needs to be played 
  */

  public AudioSource audioSource;  

  //Play an imported sound
  public void playSound()
  {
     audioSource.Play();
  }


}
