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
            UpdateHealthDisplay();
        }

        if (collision.collider.CompareTag("AR Bullet"))
        {
            TakeDamage(1);
            UpdateHealthDisplay();
        }

        if (collision.collider.CompareTag("Shotty Bullet"))
        {
            TakeDamage(20);
            UpdateHealthDisplay();
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