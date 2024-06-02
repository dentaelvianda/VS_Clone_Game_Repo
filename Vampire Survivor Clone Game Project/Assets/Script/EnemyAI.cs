using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float minEnemyTargetDistance = 10f;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    private bool chaseTarget = false;

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
            if (Vector3.Distance(transform.position, target.position) < minEnemyTargetDistance && chaseTarget)
            {
                navMeshAgent.SetDestination(target.position);
            }
        }
        
    }

    public void SetChaseTarget(bool chaseTarget)
    {
        this.chaseTarget = chaseTarget;
    }
}
