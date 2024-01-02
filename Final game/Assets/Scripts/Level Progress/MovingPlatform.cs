using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the player as a child of the platform
            playerTransform = other.transform;
            playerTransform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Detach the player from the platform
            playerTransform.SetParent(null);
        }
    }
}
