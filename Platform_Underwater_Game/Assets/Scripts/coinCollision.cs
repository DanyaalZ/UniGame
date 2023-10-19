using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCollision : MonoBehaviour
{
    //variable coin text
    public TMP_Text coinText;

    //import updater script
    public coinText coinTextUpdater;

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

        //increase coins by 1 in this instance as only coin
        coinTextUpdater.updateText(1);

    }
}
