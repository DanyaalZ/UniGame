using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script will set all guns to be inactive unless the player has the gun in their inventory and switches to them */
public class HandlePlayerGuns : MonoBehaviour
{
    //game objects for the different guns, and booleans to check if player can use them (will be based on their inventory)
    public GameObject SMG;

    private bool SMGAllowed;

    public GameObject Shotty;

    private bool ShottyAllowed;

    public GameObject AR;

    private bool ARAllowed;

    //player's gun inventory
    public GunInventory gunInventory;

    void Start()
    {
        //on start set the guns to inactive
        SMG.SetActive(false);
        Shotty.SetActive(false);
        AR.SetActive(false);

        //check if player has bought any of the guns
        foreach (string gun in gunInventory.getGuns())
        {
            if (gun == "SMG")
            {
                SMGAllowed = true;
            }

            if (gun == "Shotty")
            {
                ShottyAllowed = true;
            }

            if (gun == "AR")
            {
                ARAllowed = true;
            }
        }

    }

    void Update()
    {
        if (SMGAllowed)
        {
            //if user has SMG, they can click 1 to switch to it (disabling the other guns until they are pressed)
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Shotty.SetActive(false);
                AR.SetActive(false);

                SMG.SetActive(true);
            }
        }

        if (ShottyAllowed)
        {
            //if user has Shotty, they can click 2 to switch to it (disabling the other guns until they are pressed)
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                SMG.SetActive(false);
                AR.SetActive(false);

                Shotty.SetActive(true);
            }
        }

        if (ARAllowed)
        {
            //if user has Shotty, they can click 3 to switch to it (disabling the other guns until they are pressed)
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                SMG.SetActive(false);
                Shotty.SetActive(false);

                AR.SetActive(true);
            }
        }
    }
}
