using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;


public class PlayerControllerForTutorial : MonoBehaviour
{
    //for mouse controls
    public float sensitivity = 100f;

    //for physics
    private Rigidbody body;

    //variable text
    public TMP_Text sprintText;
    public SprintText sprintTextUpdater;
    public TMP_Text gravityText;
   

    public GravityText gravityTextUpdater;

  
    //variables for movement (speed, x, y movement)
    public float speed = 15f;
    public float jumpForce = 5f;
    private float originalSpeed;

    //used for crouch
    private CapsuleCollider playerCollider;
    private float originalColliderHeight;
    private Vector3 originalColliderCentre;

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
    private float gravityControlDuration = 5f;
    private float gravityControlTimer = 0f;

    //rotation variables
    //set angular velocity to a default of 0, so no rotation unless function called
    Vector3 bodyAngleVelocity = new Vector3(0f,0f,0f);

    //Reference to MouseLook Class
    private MouseLook mouseLook;

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

        // Lock the cursor centre of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mouseLook = GetComponentInChildren<MouseLook>();

        //get collider for crouch, as well as the original collider height, center so player cant walk through objects
        playerCollider = GetComponent<CapsuleCollider>();
        originalColliderHeight = playerCollider.height;
        originalColliderCentre = playerCollider.center;
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
        // Check if the player is not crouched, not already sprinting, and not crouching
        if (!sprinting && !crouchCheck)
        {
            sprinting = true;
            sprintTextUpdater.updateText(true);
            // Make sure speed has been reset
            originalSpeed = speed;
            // Increase speed by x1.5
            speed *= 1.5f;
        }
        else if (!crouchCheck)
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
        // Check if player is already crouched and not jumping
        if (!crouchCheck && isGrounded)
        {
            crouchCheck = true;

            // Half the speed when crouching
            speed /= 2f;

            // Set sprintTextUpdater to false when crouching
            sprintTextUpdater.updateText(false);

            // Half original height seems to work
            playerCollider.height = originalColliderHeight / 2f;
            playerCollider.center = new Vector3(originalColliderCentre.x, originalColliderCentre.y / 2f, originalColliderCentre.z);
        }
        else
        {
            // Check if not allowed to uncrouch while jumping
            if (isGrounded)
            {
                // Uncrouch
                crouchCheck = false;

                // Restore speed to original when crouch untoggled
                speed = originalSpeed;

                // Set collider back to normal on uncrouch
                playerCollider.height = originalColliderHeight;
                playerCollider.center = originalColliderCentre;
            }
        }
    }


    private bool isGravityControlActive()
    {
        return gravityCheck && gravityControlTimer > 0f;
    }

    private void Update()
    {
        // Update grav control timer
        if (isGravityControlActive())
        {
            gravityControlTimer -= Time.deltaTime;

            if (gravityControlTimer <= 0f)
            {
                // Disable gravity control when the timer reaches 0
                gravityCheck = false;
                jumpForce /= 2;
                gravityTextUpdater.updateText(true);
            }
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

    //the gravity strength controls
    private void OnGCheck()
    {
        // if user activates low gravity mode, jump stats are boosted by x2, for a 5 second period
        if (!isGravityControlActive())
        {
            gravityCheck = true;
            gravityTextUpdater.updateText(false);
            jumpForce *= 2;
            gravityControlTimer = gravityControlDuration;
        }
    }

    //For collisions against objects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object is a platform or the floor
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            // sets the player to grounded
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

        //more debug logs (remove after prototype)
        Debug.Log("Player Position After Movement: " + transform.position);
        Debug.Log("Speed1" + speed);
    }
}
