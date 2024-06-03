using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float minEnemyTargetDistance = 10f;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    private bool chaseTarget;
    private bool isEnemyMoving;
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        target = FindObjectOfType<Player>().transform;
        previousPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        isEnemyMoving = false;
        chaseTarget = false;
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
                isEnemyMoving = true;
            }
            else
            {
                isEnemyMoving = false;
            }
        }

        Vector3 currentPosition = transform.position;
        Vector3 movementDirection = currentPosition - previousPosition;

        // Cek arah gerakan musuh di sumbu X
        if (movementDirection.x < 0)
        {
            // Musuh bergerak ke kiri (flip sprite)
            spriteRenderer.flipX = true;
        }
        else if (movementDirection.x > 0)
        {
            // Musuh bergerak ke kanan (default)
            spriteRenderer.flipX = false;
        }

        previousPosition = currentPosition;
    }

    public void SetChaseTarget(bool chaseTarget)
    {
        this.chaseTarget = chaseTarget;
    }

    public bool IsEnemyMoving()
    {
        return isEnemyMoving;
    }
}
