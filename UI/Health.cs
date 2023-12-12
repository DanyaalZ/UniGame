using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float CurrentHealth;
    public LivesText livesTextUpdater; // Reference to LivesText script
    private bool isDead = false; // Flag to check if player is already dead

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Player takes damage per hit amount
    public void TakeDamage(float Amount)
    {
        if (!isDead)
        {
            CurrentHealth -= Amount;
            if (CurrentHealth <= 0)
            {
                Debug.Log("Player has died.");
                livesTextUpdater.decrementLives(); // Decrement lives
                isDead = true; // Set the flag to prevent multiple life decrements
                CurrentHealth = MaxHealth;
                transform.position = new Vector3(2.25f, 2.37f, 31.13f);
                isDead = false;
            }
        }
    }

}
