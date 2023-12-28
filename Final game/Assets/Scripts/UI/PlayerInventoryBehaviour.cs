using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInventoryBehaviour : MonoBehaviour
{
    //check if inventory is open to display
    private bool inventoryOpen;

    //to set visible/not visible
    public GameObject inventory;

    public TMP_Text inventoryText;

    public GunInventory gunInventoryObject;

    //THIS WILL BE USED TO SHOW THE INVENTORY OF GUNS
    private string gunList;

    //on start make sure inventory is not visible
    public void Start()
    {
        //retrieve gun inventory for text - take each string from array
        foreach (string gun in gunInventoryObject.getGuns()){
            gunList += (gun + ", ");
        }
    
        inventoryOpen = false;
        inventory.SetActive(false);
    }

    //when inventory button (E) pressed, open or close inventory
    public void InventoryPress()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //open
            if (inventoryOpen == false)
            {   
                inventoryOpen = true;
                inventory.SetActive(true);
            }

            //close
            else
            {   
                inventoryOpen = false;
                inventory.SetActive(false);
            }
        }
    }

    //Update inventory text as it is updated
    //Check if E button pressed
    void Update()
    {
        //retrieve gun inventory for text - take each string from array
        foreach (string gun in gunInventoryObject.getGuns()){
            gunList += (gun + ", ");
        }
    
        inventoryText.text = $"Inventory: {gunList}";
        InventoryPress();   
    }
}
