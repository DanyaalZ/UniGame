using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public Transform playerBody;
    float verticalRotation = 0.0f; // New variable for vertical rotation

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; // New line for vertical mouse input

        // Applying horizontal rotation to the player's body
        playerBody.Rotate(Vector3.up * mouseX);

        // Applying vertical rotation to the camera
        verticalRotation -= mouseY; // Subtracting to invert the vertical axis
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Clamping the rotation

        // Apply the rotation to the transform of this object (which should be the camera)
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}