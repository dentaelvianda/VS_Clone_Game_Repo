using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositionList;
    [SerializeField] private GameObject[] enemyPrefabs;

    private bool IsSpawned = false;

    public void SpawnEnemy()
    {
        if (IsSpawned) { return; }
        foreach (Transform enemyTransform in spawnPositionList)
        {
            GameObject enemySpawned = Instantiate(enemyPrefabs[GetRandomNumber()], enemyTransform);
            enemySpawned.GetComponent<EnemyAI>().SetChaseTarget(true);
        }
        IsSpawned = true;
    }

    private int GetRandomNumber()
    {
        return Random.Range(0, enemyPrefabs.Length);
    }
}
