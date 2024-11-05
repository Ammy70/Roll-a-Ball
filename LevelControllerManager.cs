using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelControlerManager : MonoBehaviour
{
    public GameObject entityToSpawn;
    [SerializeField] private CubeDB cubeDB;
    int instanceNumber = 1;

    void Start()
    {
        SpawnEntities();
    }

    private void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;
        for(int i = 0; i < cubeDB.numberOfPrefabsToCreate; i++)
        {
            // Creates an instance of the prefab at the current spawn point.
            GameObject currentEntity = Instantiate(entityToSpawn, cubeDB.spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currentEntity.name = cubeDB.prefabName + instanceNumber;

            // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % cubeDB.spawnPoints.Length;

            instanceNumber++;
        }
    
}
}
