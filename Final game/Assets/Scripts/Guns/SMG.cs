using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    public GameObject SMGBullet;
    public float shootForce = 500f;

    //where bullet shoots from
    public GameObject bulletSpawnPoint;

    void Update()
    {
        //if you left click bullet is shot constantly (hold down)
        if (Input.GetMouseButton(0))
        {
            GameObject projectile = Instantiate(SMGBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            //shoot forward
            rb.AddForce(transform.forward * shootForce);
        }
    }
}
