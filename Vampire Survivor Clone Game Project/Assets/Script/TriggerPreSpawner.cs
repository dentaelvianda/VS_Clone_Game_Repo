using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPreSpawner : MonoBehaviour
{
    private EnemyPreSpawner enemyPreSpawner;

    private void Awake()
    {
        enemyPreSpawner = GetComponentInParent<EnemyPreSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            enemyPreSpawner.SetChasingTarget(true);
        }
    }
}
