using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory : MonoBehaviour
{
   //player's gun inventory, which remains constant in game
   //type list
   public static List<string> gunInventory = new List<string>();

   //add a new gun to inventory
   public void addGun(string gunName)
   {
    gunInventory.Add(gunName);
   }

   //get guns, as a regular array to print to screen
   public string[] getGuns()
   {
    return gunInventory.ToArray();
   }
}
