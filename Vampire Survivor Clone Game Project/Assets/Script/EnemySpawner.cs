using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositionList;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float waveTimer = 5f;
    [SerializeField] private int totalWave;
    [SerializeField] private bool usingWave;

    private float waveCounter;
    private int currentWave;
 
    private bool IsSpawned = false;

    private void Update()
    {
        if (usingWave && currentWave < totalWave)
        {
            
            waveCounter += Time.deltaTime;
            if(waveCounter > waveTimer)
            {
                foreach (Transform enemyTransform in spawnPositionList)
                {
                    GameObject enemySpawned = Instantiate(enemyPrefabs[GetRandomNumber()], enemyTransform);
                    enemySpawned.GetComponent<EnemyAI>().SetChaseTarget(true);
                }
                currentWave++;
            }
            
        }
    }

    public void SpawnEnemy()
    {
        if (IsSpawned) { return; }
        foreach (Transform enemyTransform in spawnPositionList)
        {
            GameObject enemySpawned = Instantiate(enemyPrefabs[GetRandomNumber()], enemyTransform);
            enemySpawned.GetComponent<EnemyAI>().SetChaseTarget(true);
        }
        waveCounter = 0f;
        IsSpawned = true;
    }

    private int GetRandomNumber()
    {
        return Random.Range(0, enemyPrefabs.Length);
    }
}
