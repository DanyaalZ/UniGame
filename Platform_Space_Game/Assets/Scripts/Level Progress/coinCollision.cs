using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class coinCollision : MonoBehaviour
{
    //variable coin text
    public TMP_Text coinText;

    //import updater script
    public coinText coinTextUpdater;

    //amount to update coins
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

        //increase coins by amount set - variable based on treasure type
        coinTextUpdater.updateText(amountUpdate);

    }
}
