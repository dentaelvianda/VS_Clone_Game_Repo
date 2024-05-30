using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> propSpawnPoints;
    [SerializeField] private List<GameObject> propPrefabs;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps() 
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;

        }
    }
}
