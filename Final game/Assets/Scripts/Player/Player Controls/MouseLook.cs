using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script doubles as a mouse look script, and for changing input sensitivity (it contains values for changing input sensitivity, which are used by that respective script)
//this is the reason for the usePlayerBodyScript as we may not need it.
public class MouseLook : MonoBehaviour
{
    //Initialise sensitivity to 150
    public static float sensitivity = 150.0f;
    public Transform playerBody;

    //set to true by default to avoid hassle of changing in each scene, only changed for settings
    public bool usePlayerBody = true;

    float verticalRotation = 0.0f; // New variable for vertical rotation

    private void Start()
    {
        if(usePlayerBody)
        {
            //if we are in the scenes for looking around get rid of cursor for better player visibility
            //if we are in settings, we need the cursor so it will still be shown
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        //if we are in the scenes for actually looking around, not changing sensitivity
        if(usePlayerBody)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; 

            //applying horizontal rotation to the player's body (mouse x to look left and right)
            playerBody.Rotate(Vector3.up * mouseX);

            //applying vertical rotation to the camera
            //subtracting to invert the vertical axis 
            verticalRotation -= mouseY; 
            //clamping the rotation
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); 

            //apply the rotation to the transform of this object (which should be the camera) (mousey to look up and down)
            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }

    //access and change sensitivity variable (for slider)
    public void changeSensitivity(float newSensitivity)
    {
        sensitivity = newSensitivity;
    }

    //get sensitivity as needed for slider

    public float getSensitivity()
    {
        return sensitivity;
    }
}