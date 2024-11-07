using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnSpotsList = new();
    [SerializeField] private CubeSpawnConfig _cubeSpawnConfig;
    
    void Start()
    {
        SpwanCubeSpots();
    }

    private void SpwanCubeSpots()
    {
        int count = 0;
        while (count < _cubeSpawnConfig.numberOfPrefabsToCreate)
        {
            int randomSpawnSpot = Random.Range(0, _spawnSpotsList.Count); // ->
            Instantiate(_cubeSpawnConfig.prefabToSpawn, _spawnSpotsList[randomSpawnSpot].position, Quaternion.identity); // ->
            _spawnSpotsList.Remove(_spawnSpotsList[randomSpawnSpot]);
            count++;
        }
    }
}
