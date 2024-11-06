using UnityEngine;
using System.Collections.Generic;

public class LevelControlerManager : MonoBehaviour
{
    [SerializeField] private CubeSpawnConfig _cubeSpawnConfig;
    [SerializeField] private List<GameObject> _spawnPoints = new();

    void Start()
    {
        SpawnEntities();
    }

    private void SpawnEntities()
    {
        for (int i = 0; i < _cubeSpawnConfig.numberOfPrefabsToCreate; i++)
        {
            GameObject spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            
            GameObject currentEntity = Instantiate(_cubeSpawnConfig.prefabToSpawn, spawnPoint.transform.position,
                Quaternion.identity);
        }
    }
}
