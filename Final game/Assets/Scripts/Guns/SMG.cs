using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    public GameObject SMGBullet;
    public float shootForce = 500f;

    //where bullet shoots from
    public GameObject bulletSpawnPoint;

    public AlertWindow alertWindow;

    public GameSounds gameSounds;

    public DifficultyModes difficultyModes;

    //so out of bullets alert is not shown constantly
    private bool shownOutOfBulletAlert;

    //number of bullets for SMG (default normal)
    private int numBullets = 2000;

    void Start()
    {
        //increase or decrease bullets depending on difficulty mode
        if (difficultyModes.getMode() == "Easy")
        {
            numBullets = 20000;
        }

        if (difficultyModes.getMode() == "Hard")
        {
            numBullets = 1000;
        }

        if (difficultyModes.getMode() == "Veteran")
        {
            numBullets = 200;
        }

        //normal mode
        else
        {
            numBullets = 2000;
        }

    }

    void Update()
    {
        //if you left click bullet is shot constantly (hold down) - provided player has bullets
        if (Input.GetMouseButton(0) && numBullets > 0)
        {
            gameSounds.playSound();
            GameObject projectile = Instantiate(SMGBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
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
                alertWindow.showAlert("Out of SMG Bullets, switch weapon if you have others");
                shownOutOfBulletAlert = true;
            }
        } 
    }
}
