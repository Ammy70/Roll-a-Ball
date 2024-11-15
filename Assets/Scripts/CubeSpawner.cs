using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnSpotsList = new();
    [SerializeField] private List<CubeSpawnConfig> _cubeSpawnConfigs = new();

    public static int LevelNumber = 0;
    
    void Start()
    {
        SpwanCubeSpots();
    }

    private void SpwanCubeSpots()
    {
        int count = 0;
        int level = LevelNumber - 1;
        
        while (count < _cubeSpawnConfigs[level].numberOfPrefabsToCreate)
        {
            int randomSpawnSpot = Random.Range(0, _spawnSpotsList.Count); // ->
            Instantiate(_cubeSpawnConfigs[level].prefabToSpawn, _spawnSpotsList[randomSpawnSpot].position,
                Quaternion.identity); // ->
            _spawnSpotsList.Remove(_spawnSpotsList[randomSpawnSpot]);
            count++;
        }
    }
}
