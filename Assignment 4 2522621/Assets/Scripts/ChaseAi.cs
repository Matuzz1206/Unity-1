using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ChaseAI : MonoBehaviour
{
    public float chaseSpeed = 6f;

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
        agent.speed = chaseSpeed;
    }

    void Update()
    {
        if (player == null)
            return;
        agent.SetDestination(player.position);
    }
}