/*
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public float DetectionRange; // Range within which the player is detected
    public float SightRange;     // Range within which the player is seen

    private bool isPlayerDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player in detection range
        if (Vector3.Distance(player.position, transform.position) <= DetectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, SightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    isPlayerDetected = true;
                    agent.SetDestination(player.position); // Follow the player
                }
            }
        }
        else
        {
            isPlayerDetected = false;
            // Additional logic for when the player is not detected (e.g., return to patrol)
        }
    }
}
*/

using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public float DetectionRange; // Range within which the player is detected
    public float SightRange;     // Range within which the player is seen

    public Transform[] patrolPoints; // Array of patrol points
    private int currentPatrolIndex;  // Current patrol point index
    private bool isPlayerDetected = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPatrolIndex = 0;
        MoveToNextPatrolPoint();
    }

    void Update()
    {
        // Check for player in detection range
        if (Vector3.Distance(player.position, transform.position) <= DetectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, SightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    isPlayerDetected = true;
                    agent.SetDestination(player.position); // Follow the player
                    return; // Skip patrol logic if player is detected
                }
            }
        }

        isPlayerDetected = false;

        // Patrol logic
        if (!isPlayerDetected && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPatrolPoint();
        }
    }

    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        Vector3 patrolPointPosition = patrolPoints[currentPatrolIndex].position;
        Vector3 randomOffset = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        agent.SetDestination(patrolPointPosition + randomOffset);

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

}
