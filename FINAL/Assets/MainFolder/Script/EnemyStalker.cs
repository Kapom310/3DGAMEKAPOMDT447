using UnityEngine;
using UnityEngine.AI;

public class EnemyStalker : MonoBehaviour
{
    [Header("Settings")]
    public Transform player; // Assign the player's transform in the Inspector
    public float detectionRange = 10f; // How close the player needs to be for the enemy to start following
    public float stoppingDistance = 2f; // How close the enemy can get to the player
    public float movementSpeed = 3.5f; // Speed of the enemy
    public float roamRange = 20f; // Range within which the enemy will roam
    public float roamInterval = 5f; // Time interval between choosing new roam points

    private NavMeshAgent agent;
    private bool isChasing = false;
    private float timeSinceLastRoam;

    private void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Set up the agent
        agent.speed = movementSpeed;
        agent.stoppingDistance = stoppingDistance;

        // If player is not assigned, try to find it by tag
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player not found! Assign the player manually or tag the player object with 'Player'.");
            }
        }

        // Initialize roaming
        timeSinceLastRoam = roamInterval;
    }

    private void Update()
    {
        if (player == null) return; // Exit if there's no player to follow

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within detection range
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // If chasing, move towards the player
        if (isChasing)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            // Roam around if the player is out of range
            Roam();
        }
    }

    private void Roam()
    {
        // Increment the time since the last roam
        timeSinceLastRoam += Time.deltaTime;

        // Check if it's time to choose a new roam point
        if (timeSinceLastRoam >= roamInterval)
        {
            // Reset the timer
            timeSinceLastRoam = 0f;

            // Generate a random point within the roam range
            Vector3 randomDirection = Random.insideUnitSphere * roamRange;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, roamRange, NavMesh.AllAreas);

            // Set the destination to the random point
            agent.SetDestination(hit.position);
        }
    }

    // Draw detection range in the editor for debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, roamRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(" Hit ");

            if (this.CompareTag("Coin"))
            {
                Destroy(gameObject);
            }
        }
    }
}