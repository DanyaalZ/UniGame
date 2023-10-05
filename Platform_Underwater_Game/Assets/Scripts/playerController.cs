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
    public float speed = 20f;
    public float jumpForce = 5f;
    private float originalSpeed;

    private float XAxis;
    private float YAxis;

    //some variables for keys pressed
    private bool sprinting = false;
    private bool isGrounded = true;
 

    void Start()
    {
        //on start, assign body for player object (in code)
        body = GetComponent<Rigidbody>();

        //Set drag, gravity
        //drag used for water resistance
        body.drag = 2f;
        body.useGravity = true;

        //Lock rotation for now
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

        //set in the unity editor
        originalSpeed = speed;
    }

    //WASD to move
    private void OnMove(InputValue movementAmount)
    {
        //create vectors for player movements
        //2D vector, as only x,y required
        Vector2 movementVector = movementAmount.Get<Vector2>();

        XAxis = movementVector.x;
        YAxis = movementVector.y;
    }

    //left shift to sprint
    private void OnSprint()
    {
        //if not already sprinting, start
        if (!sprinting)
        {
            sprinting = true;
            //make sure speed has been reset
            originalSpeed = speed;
            //increase speed 2
            speed *= 2f; 
        }

        else
        {
            // Stop sprinting
            sprinting = false;
            speed = originalSpeed;
        }
    }

    //when space pressed to jump
    private void OnJump()
    {
        if (isGrounded)
        {
            //Add jump force, impulse used as it simulates a jump properly
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    //check for ground collisions 
    private void OnCollisionEnter(Collision collision)
    {
        //if player collides with floor, they are on the ground (used for jump)
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    // Fixed intervals of updates
    void FixedUpdate()
    {
        //remove debugs after prototype
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
