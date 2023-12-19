using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class lifeCollision : MonoBehaviour
{
    //variable coin text
    public TMP_Text healthText;

    //import updater script
    public LivesText healthTextUpdater;

    //amount to update lives
    public int amountUpdate;

    //get gameobject for visisibility on/off (coin)
    public GameObject coinVisibility;
    
    //on start get the renderer
    void Start()
    {
        coinVisibility.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //when object touched by player, remove it (set to invisible)
        coinVisibility.SetActive(false);

        //increase health by amount to update on collision with health power up
        healthTextUpdater.incrementLives(amountUpdate);
    }
}
