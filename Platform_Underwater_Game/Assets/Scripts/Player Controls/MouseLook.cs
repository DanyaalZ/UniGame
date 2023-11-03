using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public Transform playerBody; // Assign this to the transform of your player's body

    private float xRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    private void Update()
    {
        // Getting the mouse input for X
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
       
        // Left and right rotation applied to the player's body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}