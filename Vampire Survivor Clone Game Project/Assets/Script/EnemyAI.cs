using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    private Transform target;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        target = FindObjectOfType<Player>().transform;
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) < 10f)
            {
                navMeshAgent.SetDestination(target.position);
            }
        }
        
    }

    
}
