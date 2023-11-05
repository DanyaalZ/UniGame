using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResponse : MonoBehaviour
{
    public float threshold; // The Y position threshold for triggering a response.

    // Check if the Y position is below the threshold and reset if needed.
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(2.25f, 2.37f, 31.13f);
        }
    }
}
