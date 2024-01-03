using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public float Damage;
    public GameSounds gameSounds;
    public float KOTime; // Knockout time after attacking
    public float MaxHealth;
    public float CurrentHealth;
    public TMP_Text EnemyHealthText; // UI for displaying health
    public Transform EnemyHealthTextPosition;
    public NavMeshAgent agent; // Reference to NavMeshAgent
    private bool isAttacking = false; // Flag to check if enemy is currently attacking

    void Start()
    {
        CurrentHealth = MaxHealth; // Initialize current health to max health
        UpdateHealthDisplay(); // Initial display update
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage; // Reduce health by damage amount
        UpdateHealthDisplay(); // Update display after taking damage
        if (CurrentHealth <= 0)
        {
            Die(); // Check for death
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Handle death (destroying the GameObject)
    }

    void Update()
    {
        UpdateHealthDisplayPosition(); // Continuously update health display position

        //death sound
        if (CurrentHealth < 15)
        {
            gameSounds.playSound();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Disable kinematics when colliding with certain objects
        // this will essentially create a knockback effect when the npc is shot by guns
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("SMG Bullet") || collision.collider.CompareTag("AR Bullet") || collision.collider.CompareTag("Shotty Bullet"))
        {
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            // the enemy NPC loses 10hp for every time they receive a melee attack from the player
            if (!isAttacking && collision.collider.CompareTag("Player"))
            {
                collision.collider.gameObject.GetComponent<Health>().TakeDamage(Damage);
                StartCoroutine(AttackDelay(KOTime));
            }

            //bullet damage
            if (collision.collider.CompareTag("SMG Bullet"))
            {
                Debug.Log("smg");
                TakeDamage(1);
            }

            if (collision.collider.CompareTag("AR Bullet"))
            {
                TakeDamage(1);
            }

            if (collision.collider.CompareTag("Shotty Bullet"))
            {
                TakeDamage(20);
            }

            UpdateHealthDisplay();
            // Re-enable kinematics after a short delay
            StartCoroutine(ReenableKinematicsAfterDelay(1f)); // 1 second delay
        }
    }

    IEnumerator AttackDelay(float Delay)
    {
        isAttacking = true;
        agent.isStopped = true; // Stop movement during attack
        yield return new WaitForSeconds(Delay);
        agent.isStopped = false; // Resume movement
        isAttacking = false;
    }

    IEnumerator ReenableKinematicsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    private void UpdateHealthDisplay()
    {
        if (EnemyHealthText != null)
        {
            EnemyHealthText.text = CurrentHealth.ToString() + "%"; // Display current health
        }
    }

    private void UpdateHealthDisplayPosition()
    {
        if (EnemyHealthText != null)
        {
            EnemyHealthText.transform.position = EnemyHealthTextPosition.position;
            EnemyHealthText.transform.rotation = Quaternion.LookRotation(EnemyHealthText.transform.position - Camera.main.transform.position);
        }
    }
}
