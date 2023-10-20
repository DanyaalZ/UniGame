using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // sens for mouse movement
    public float sensitivity = 2.0f;
    // current rotation for X-axis
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Update()
    {
        // Horizontal and vertical mouse inputs
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y"); // NEED TO IMPLEMENT

        rotationY += mouseX * sensitivity;

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        // transform.parent.rotation *= Quaternion.Euler(0, mouseX * sensitivity, 0);
    }
}
