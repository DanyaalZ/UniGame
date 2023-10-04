using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    //for physics
    private Rigidbody body;

    //variables for movement (speed, x, y movement)
    public float speed = 0;
    private float originalSpeed;

    private float XAxis;
    private float YAxis;

    private bool sprinting = false;
    private bool jumping = false;

    void Start()
    {
        //set in the unity editor
        originalSpeed = speed;

        //on start, assign body for player object (in code)
        body = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementAmount)
    {
        //create vectors for player movements
        //2D vector, as only x,y required
        Vector2 movementVector = movementAmount.Get<Vector2>();

        XAxis = movementVector.x;
        YAxis = movementVector.y;
    }

    private void OnSprint()
    {
        //if not already sprinting, start
        if (!sprinting)
        {
            sprinting = true;
            //make sure speed has been reset
            originalSpeed = speed;
            //increase speed by factor of 2
            speed *= 2f; 
        }

        else
        {
            // Stop sprinting
            sprinting = false;
            speed = originalSpeed;
        }
    }

    private void OnJump()
    {
        if(!jumping)
        {
            jumping = true;
            YAxis += 10;
            System.Threading.Thread.Sleep(1000);
            YAxis -= 10;
        }

        else
        {
            jumping = true;
        }
    }

    // Fixed intervals of updates
    void FixedUpdate()
    {
        Debug.Log("XAxis: " + XAxis);
        Debug.Log("YAxis: " + YAxis);
        Debug.Log("Player Position: " + transform.position);
        //3D Vector for 3D object
        Vector3 movement = new Vector3(XAxis, 0f, YAxis);
        //add movement, speed to player object as it moves
        body.AddForce(movement * speed);
        Debug.Log("Player Position After Movement: " + transform.position);
        Debug.Log("Speed1" + speed);
    }
}
