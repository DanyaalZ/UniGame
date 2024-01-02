using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerGuns : MonoBehaviour
{
    // Game objects for the different guns
    public GameObject SMG;
    public GameObject Shotty;
    public GameObject AR;

    // Booleans to check if player can use these guns
    private bool SMGAllowed;
    private bool ShottyAllowed;
    private bool ARAllowed;

    // Player's gun inventory
    public GunInventory gunInventory;

    // Reference to the PlayerController script
    public PlayerController playerController;

    void Start()
    {
        // On start, set the guns to inactive
        SMG.SetActive(false);
        Shotty.SetActive(false);
        AR.SetActive(false);

        // Check if player has bought any of the guns
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
        // SMG
        if (SMGAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Shotty.SetActive(false);
                AR.SetActive(false);
                SMG.SetActive(true);
                playerController.SetWeaponEquipped(true); // Disable melee attack
            }
        }

        // Shotty
        if (ShottyAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SMG.SetActive(false);
                AR.SetActive(false);
                Shotty.SetActive(true);
                playerController.SetWeaponEquipped(true); // Disable melee attack
            }
        }

        // AR
        if (ARAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SMG.SetActive(false);
                Shotty.SetActive(false);
                AR.SetActive(true);
                playerController.SetWeaponEquipped(true); // Disable melee attack
            }
        }

        // Melee (no guns)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Shotty.SetActive(false);
            AR.SetActive(false);
            SMG.SetActive(false);
            playerController.SetWeaponEquipped(false); // Enable melee attack
        }
    }
}
