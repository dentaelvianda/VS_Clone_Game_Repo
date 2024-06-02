using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            enemySpawner.SpawnEnemy();
        }
    }
}
