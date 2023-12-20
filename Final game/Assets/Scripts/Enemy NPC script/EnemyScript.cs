using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public float Damage;
    public float KOTime; // Knockout time after attacking

    public float MaxHealth;
    private float CurrentHealth;
    public TMP_Text EnemyHealthText;
    public Transform EnemyHealthTextPosition;

    public NavMeshAgent agent; // Reference to NavMeshAgent

    private bool isAttacking = false; // Flag to check if enemy is currently attacking

    void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthDisplay();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        UpdateHealthDisplayPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isAttacking && collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(Damage);
            StartCoroutine(AttackDelay(KOTime));
        }
    }

    IEnumerator AttackDelay(float Delay)
    {
        isAttacking = true;
        agent.isStopped = true; // Stop NavMeshAgent movement

        yield return new WaitForSeconds(Delay);

        agent.isStopped = false; // Resume NavMeshAgent movement
        isAttacking = false;
    }

    private void UpdateHealthDisplay()
    {
        if (EnemyHealthText != null)
        {
            EnemyHealthText.text = "Health: " + CurrentHealth.ToString();
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
