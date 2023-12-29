using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotty : MonoBehaviour
{
    public GameObject ShottyBullet;
    public float shootForce = 5000f;

    public DifficultyModes difficultyModes;

    //where bullet shoots from
    public GameObject bulletSpawnPoint;

    public GameSounds gameSounds;

    //number of bullets for AR (default normal)
    private int numBullets = 50;

    //so out of bullets alert is not shown constantly
    private bool shownOutOfBulletAlert;

    public AlertWindow alertWindow;

    void Start()
    {
        //increase or decrease bullets depending on difficulty mode
        if (difficultyModes.getMode() == "Easy")
        {
            numBullets = 100;
        }

        if (difficultyModes.getMode() == "Hard")
        {
            numBullets = 25;
        }

        if (difficultyModes.getMode() == "Veteran")
        {
            numBullets = 10;
        }

        //normal mode
        else
        {
            numBullets = 50;
        }

    }

    void Update()
    {
        //if you left click bullet is shot one at a time - provided user has bullets
        if (Input.GetMouseButtonDown(0) && numBullets > 0)
        {
            gameSounds.playSound();
            GameObject projectile = Instantiate(ShottyBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            //shoot forward
            rb.AddForce(transform.forward * shootForce);
            numBullets--;
        }

        //when bullets run out tell player to switch weapon
        if (numBullets == 0)
        {
            if (!shownOutOfBulletAlert)
            {
                alertWindow.showAlert("Out of Shotty Bullets, switch weapon if you have others");
                shownOutOfBulletAlert = true;
            }
        } 
    }
}
