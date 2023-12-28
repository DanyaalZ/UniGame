using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/* Defines the behaviour of the player inventory - including opening, closing, storing guns which are bought, and using said guns */
public class PlayerInventoryBehaviour : MonoBehaviour
{
    //check if inventory is open
    private bool inventoryOpen;

    //inventory object to allow to set visibility (on E pressed)
    public GameObject inventory;

    //text component to display inventory contents
    public TMP_Text inventoryText;

    //GunInventory object holding the list of guns
    public GunInventory gunInventoryObject;

    //string to store the list of guns for display
    private string gunList;


    public void Start()
    {
        inventoryOpen = false;
        //ensure inventory is not visible at start
        inventory.SetActive(false); 
        //update inventory list on start
        UpdateInventoryList(); 
    }

    //updates the gun list string for display
    private void UpdateInventoryList()
    {
        //reset the gun list to avoid duplication
        gunList = ""; 
        //loop through each gun in inventory and add to the gun list
        foreach (string gun in gunInventoryObject.getGuns())
        {
            gunList += (gun + ", ");
        }
        //update inventory text for display
        inventoryText.text = $"Inventory: {gunList}"; 
    }

    //called to handle inventory open and close on E pressed
    public void InventoryPress()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryOpen = !inventoryOpen; 
            //set inventory visibility
            inventory.SetActive(inventoryOpen); 

            if (inventoryOpen)
            {
                 //update inventory list when opened
                UpdateInventoryList();
            }
        }
    }

    void Update()
    {
        //check for inventory open/close key press (E)
        InventoryPress(); 
    }
}
