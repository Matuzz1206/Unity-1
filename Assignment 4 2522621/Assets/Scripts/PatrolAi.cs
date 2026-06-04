using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PatrolAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float chaseDistance = 15f;

    private int currentPoint = 0;
    private NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer()
    {
        while (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                player = p.transform;
                break;
            }
            yield return null;
        }

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
        else
        {
            Debug.LogError("PatrolAI ERROR: No patrol points assigned!");
        }
    }

    void Update()
    {

        if (player == null || patrolPoints.Length == 0)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            agent.SetDestination(player.position);
            return;
        }
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }
}