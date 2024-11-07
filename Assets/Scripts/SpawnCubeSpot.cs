using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubeSpot : MonoBehaviour
{
    private List<Transform> spawnSpotsList;
    public Transform[] spawnSpots;
    public GameObject CubeSpot;
    private int randomSpawnSpot;
    private int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpotsList = new List<Transform>(spawnSpots);
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
        SpwanCubeSpots();

    }

    private void SpwanCubeSpots()
    {
        while (x <= 9)
        {
            randomSpawnSpot = Random.Range(0, spawnSpots.Length);
            Instantiate(CubeSpot, spawnSpots[randomSpawnSpot].position, Quaternion.identity);
            Destroy(spawnSpots[randomSpawnSpot].gameObject);
            x++;
        }
    }

    
}
