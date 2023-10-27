using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResponse : MonoBehaviour
{
    public float threshold;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(2.25f, 2.37f, 31.13f);
        }
    }
}
