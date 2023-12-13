using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro support

public class Health : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] public float CurrentHealth;
    public LivesText livesTextUpdater; // Reference to LivesText script
    public TMP_Text healthTextUpdater; // Reference to the TextMeshPro UI element for health
    private bool isDead = false; // Flag to check if player is already dead

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthDisplay(); // Update health display at the start
    }

    // Player takes damage per hit amount
    public void TakeDamage(float Amount)
    {
        if (!isDead)
        {
            CurrentHealth -= Amount;
            UpdateHealthDisplay(); // Update health display whenever health changes

            if (CurrentHealth <= 0)
            {
                Debug.Log("Player has died.");
                livesTextUpdater.decrementLives(); // Decrement lives
                isDead = true; // Set the flag to prevent multiple life decrements
                CurrentHealth = MaxHealth;
                UpdateHealthDisplay(); // Update health display after resetting health
                transform.position = new Vector3(2.25f, 2.37f, 31.13f); // Respawn position
                isDead = false;
            }
        }
    }

    // Method to update the health display
    private void UpdateHealthDisplay()
    {
        if (healthTextUpdater != null)
        {
            healthTextUpdater.text = "Health: " + CurrentHealth.ToString();
        }
    }
}
