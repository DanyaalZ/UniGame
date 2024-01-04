using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    private Vector3 platformLastPosition; // Stores the last position of the platform
    private Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        // Initialize platform's last position to its current position at the start
        platformLastPosition = transform.position;
    }

    void Update()
    {
        // Check if the player is currently on the platform
        if (playerTransform != null)
        {
            // Calculate how much the platform has moved since the last frame
            Vector3 deltaPosition = transform.position - platformLastPosition;

            // Move the player by the same amount the platform has moved
            playerTransform.position += deltaPosition;
        }

        // Update the platform's last position for the next frame
        platformLastPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Assign the player's transform to playerTransform
            playerTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Clear the playerTransform when the player leaves the platform
            playerTransform = null;
        }
    }
}
