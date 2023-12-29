using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    public GameObject ARBullet;
    public float shootForce = 1000f;

    public DifficultyModes difficultyModes;

    //where bullet shoots from
    public GameObject bulletSpawnPoint;

    //number of bullets for AR (default normal)
    private int numBullets = 1000;

    //so out of bullets alert is not shown constantly
    private bool shownOutOfBulletAlert;

    public AlertWindow alertWindow;

    void Start()
    {
        //increase or decrease bullets depending on difficulty mode
        if (difficultyModes.getMode() == "Easy")
        {
            numBullets = 10000;
        }

        if (difficultyModes.getMode() == "Hard")
        {
            numBullets = 500;
        }

        if (difficultyModes.getMode() == "Veteran")
        {
            numBullets = 100;
        }

        //normal mode
        else
        {
            numBullets = 1000;
        }

    }

    void Update()
    {
        //if you left click bullet is shot constantly (hold down) - provided user has bullets
        if (Input.GetMouseButton(0) && numBullets > 0)
        {
            GameObject projectile = Instantiate(ARBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
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
                alertWindow.showAlert("Out of AR Bullets, switch weapon if you have others");
                shownOutOfBulletAlert = true;
            }
        } 
    }
}
