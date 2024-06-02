using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPreSpawner : MonoBehaviour
{
    private EnemyAI[] enemies;

    private void Awake()
    {
        enemies = GetComponentsInChildren<EnemyAI>();
    }

    public void SetChasingTarget(bool isChasingTarget)
    {
        foreach (EnemyAI enemy in enemies)
        {
            enemy.SetChaseTarget(isChasingTarget);
        }
    }
}
