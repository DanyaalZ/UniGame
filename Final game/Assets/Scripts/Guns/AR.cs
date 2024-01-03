using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    public GameObject ARBullet;
    public float shootForce = 1000f;
    public DifficultyModes difficultyModes;

    // where bullets shoot from
    public GameObject bulletSpawnPoint;

    // default no. bullets for AR
    private int numBullets = 1000;
    public GameSounds gameSounds;

    // so out of bullets alert for AR is not shown constantly
    private bool shownOutOfBulletAlert;
    public AlertWindow alertWindow;


    // increase/decrease no. bullets depending on difficulty mode
    void Start()
    {
        if (difficultyModes.getMode() == "Easy")
        {
            numBullets = 10000;
        }
        else if (difficultyModes.getMode() == "Hard")
        {
            numBullets = 500;
        }
        else if (difficultyModes.getMode() == "Veteran")
        {
            numBullets = 100;
        }
        else
        {
            numBullets = 1000; // Normal mode
        }
    }

    void Update()
    {
        // //if you left click bullet is shot constantly (hold down) - provided user has bullets
        if (Input.GetMouseButton(0) && numBullets > 0)
        {
            gameSounds.playSound();
            GameObject projectile = Instantiate(ARBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            // shoots forward
            rb.AddForce(bulletSpawnPoint.transform.forward * shootForce); // Use bulletSpawnPoint's forward direction
            numBullets--;
        }

        // when bullets run out tell player to switch weapon
        if (numBullets == 0 && !shownOutOfBulletAlert)
        {
            alertWindow.showAlert("Out of AR Bullets, switch weapon if you have others");
            shownOutOfBulletAlert = true;
        }
    }
}
