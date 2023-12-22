using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] public float CurrentHealth;
    public LivesText livesTextUpdater; // Reference to LivesText script
    public TMP_Text healthTextUpdater; // Reference to the TextMeshPro UI element for health
    private bool isDead = false; // Flag to check if player is already dead
    public float respawnDelay = 0.5f; // Delay before respawning

    void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthDisplay();
    }

    public void TakeDamage(float Amount)
    {
        if (!isDead)
        {
            CurrentHealth -= Amount;
            UpdateHealthDisplay();

            if (CurrentHealth <= 0)
            {
                Debug.Log("Player has died.");
                if (!isDead)
                {
                    isDead = true; // Set the flag to prevent multiple life decrements
                    livesTextUpdater.decrementLives();
                    StartCoroutine(Respawn());
                }
            }
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        CurrentHealth = MaxHealth;
        UpdateHealthDisplay();
        transform.position = new Vector3(2.25f, 2.37f, 31.13f); // Respawn position
        isDead = false;
    }

    private void UpdateHealthDisplay()
    {
        if (healthTextUpdater != null)
        {
            healthTextUpdater.text = "Health: " + CurrentHealth.ToString() + "%";
        }
    }
}
