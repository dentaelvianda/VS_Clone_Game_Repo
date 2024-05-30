using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] terrainChunks;
    [SerializeField] private int gridSize = 5;
    [SerializeField] private int terrainSize = 20;

    private void Start()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        for (int x = -gridSize; x < gridSize; x++)
        {
            for (int y = -gridSize; y < gridSize; y++)
            {
                SpawnTerrainAtGridPosition(x, y);
            }
        }
    }

    private void SpawnTerrainAtGridPosition(int x, int y)
    {
        Vector3 terrainWorldPos = new Vector3(x * terrainSize, y * terrainSize, 0);
        GameObject terrainPrefab = GetRandomTerrainPrefab();

        var terrainSpawned = Instantiate(terrainPrefab, terrainWorldPos, Quaternion.identity);
        terrainSpawned.transform.parent = transform;
    }

    private GameObject GetRandomTerrainPrefab()
    {
        int randomIndex = Random.Range(0, terrainChunks.Length);
        return terrainChunks[randomIndex];
    }
}
