using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public const string IS_WALKING = "IsWalking";

    [SerializeField] private EnemyAI enemyAI;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator != null)
        {
            animator.SetBool(IS_WALKING, enemyAI.IsEnemyMoving());
        }
    }
}
