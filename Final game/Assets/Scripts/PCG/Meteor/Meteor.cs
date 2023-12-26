using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    //for meteor movement - meteor speed
    public float speed = 5f; 

    //Move individual meteors
    void Start()
    {
        //move meteor forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
