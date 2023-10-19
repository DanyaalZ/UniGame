using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    //for physics
    private Rigidbody body;

    //variable text
    public TMP_Text sprintText;
    public SprintText sprintTextUpdater;
    public TMP_Text gravityText;
    public GravityText gravityTextUpdater;
  

    //tutorial text
    public TMP_Text tutorialText1;
   

    //variables for movement (speed, x, y movement)
    public float speed = 20f;
    public float jumpForce = 5f;
    private float originalSpeed;

    //used for movement (WASD)
    private float XAxis;
    private float YAxis;

    //some variables for keys pressed
    private bool sprinting = false;
    private bool isGrounded = true;
    private bool strafeLeftCheck = false;
    private bool strafeRightCheck = false;
    private bool crouchCheck = false;
    private bool gravityCheck = false;

    //rotation variables
    //set angular velocity to a default of 0, so no rotation unless function called
    Vector3 bodyAngleVelocity = new Vector3(0f,0f,0f);
    private bool rotateLeftCheck = false;
    private bool rotateRightCheck = false;

    void Start()
    {
        //on start, assign body for player object (in code)
        body = GetComponent<Rigidbody>();

        //sprint on/off text
        sprintText = GetComponent<TMP_Text>();


        //gravityText on.off
        gravityText = GetComponent<TMP_Text>();

        //Set drag, gravity
        //drag used for water resistance
        body.drag = 2f;
        body.useGravity = true;

        //Lock rotation for now to prevent unwanted movement
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
            sprintTextUpdater.updateText(true);
            //make sure speed has been reset
            originalSpeed = speed;
            //increase speed 2
            speed *= 2f; 
        }

        else
        {
            // Stop sprinting
            sprinting = false;
            sprintTextUpdater.updateText(false);
            speed = originalSpeed;
        }
    }

    //strafe left when left arrow key pressed
    private void OnStrafeLeft()
    {
        if(!strafeLeftCheck)
        {
            strafeLeftCheck = true;

            //Strafe left by adding body force and impulsivity for realistic effect
            body.AddForce(Vector3.left * 10, ForceMode.Impulse);
        }

        strafeLeftCheck = false;
    }

    //strafe right when left arrow key pressed
    private void OnStrafeRight()
    {
        if (!strafeRightCheck)
        {
            strafeRightCheck = true;

            //Strafe left by adding body force and impulsivity for realistic effect
            body.AddForce(Vector3.right * 10, ForceMode.Impulse);
        }

        strafeRightCheck = false;
    }
    private void OnCrouch()
    {
        //check if player is already crouched and not jumping
        if (!crouchCheck && isGrounded)
        {
            crouchCheck = true;

            //force down force
            body.AddForce(Vector3.down * 1, ForceMode.Impulse);

            //allow player to go lower by disabling collider
            GetComponent<Collider>().enabled = false;

            //make sure player doesnt fall through platforms
            body.useGravity = false;
        }
        else
        {
            //again not allowed while jumping
            if(isGrounded)
            {
                //uncrouch
                crouchCheck = false;

                //put player back in previous position
                body.AddForce(Vector3.up * 1, ForceMode.Impulse);

                //reenable collider to allow for collisions
                GetComponent<Collider>().enabled = true;

                //enable gravity when standing up
                body.useGravity = true;
            }
        }
    }
//allows user to look left and right relevant to movement of the mouse
    private void Update()
    {
        //gets input for the mouse 
        float mouseX = Input.GetAxis("Mouse X");

        //checks location of mouse
        if (mouseX != 0f)
        {
            //allows it to rotate left
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            //movement of player based on speed of mouse move 
            float rotationSpeed = 500f; //choose speed 
            bodyAngleVelocity = new Vector3(0f, mouseX * rotationSpeed, 0f);
        }
        else
        {
            //stops movement if there is no mouse movement 
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            bodyAngleVelocity = Vector3.zero;
        }
    }


    //when space pressed to jump
    private void OnJump()
    {
        //Add jump force, impulse used as it simulates a jump properly
        if (isGrounded)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnGCheck()
    {
        if (!gravityCheck)
        {
            gravityCheck = true;
            gravityTextUpdater.updateText(false);
            jumpForce *= 2;
        }

        else
        {
            gravityCheck = false;
            jumpForce /= 2;
            gravityTextUpdater.updateText(true);
        }
    }


    //for collisions
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

        //calculate the movement vector based on the rotation
        //this way player will move in direction of any rotation
        Vector3 forwardDirection = transform.forward * YAxis;
        Vector3 rightDirection = transform.right * XAxis;
        //we normalise to get only the direction, no magnitude
        Vector3 directionOfMovement = (forwardDirection + rightDirection).normalized;

        //add force (velocity) for movement
        body.AddForce(directionOfMovement * speed);


        //rotation code - should be 0 rotation unless button pressed
        //a quaternion represents a rotation
        Quaternion deltaRotation = Quaternion.Euler(bodyAngleVelocity * Time.fixedDeltaTime);
        body.MoveRotation(body.rotation * deltaRotation);

        //more debug logs
        Debug.Log("Player Position After Movement: " + transform.position);
        Debug.Log("Speed1" + speed);
    }
}
