using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet should disappear on a collision - or decrease enemy health
    void OnCollisionEnter(Collision collision)
    {
        //when the bullet hits something (surface), not enemy it disappears
        if (!gameObject.CompareTag("EnemyNPC"))
        {
            gameObject.SetActive(false); 
        }
    }
}
