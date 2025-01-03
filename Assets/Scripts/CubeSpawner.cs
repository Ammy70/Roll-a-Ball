using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] public List<Transform> _spawnSpotsList = new();
    [SerializeField] public List<CubeSpawnConfig> _cubeSpawnConfigs = new();
    public static int LevelNumber = 4;
    void Start()
    {

        SpwanCubeSpots();
    }
    public void SpwanCubeSpots()
    {
        int count = 0;
        int level = LevelNumber - 1;


        Debug.Log($"Level {level}");

        for (int i = 0; i < _cubeSpawnConfigs[level].numberOfPrefabsToCreate; i++)
        {
            int randomSpawnSpot = Random.Range(0, _spawnSpotsList.Count); // ->
            Instantiate(_cubeSpawnConfigs[level].prefabToSpawn, 
                _spawnSpotsList[randomSpawnSpot].position,
                Quaternion.identity); // ->
            _spawnSpotsList.Remove(_spawnSpotsList[randomSpawnSpot]);
            count++;
            print("cubeSpwan");
        }
    }
}
