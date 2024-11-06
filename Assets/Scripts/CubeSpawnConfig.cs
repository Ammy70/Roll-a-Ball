using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class CubeSpawnConfig : ScriptableObject
{
    public GameObject prefabToSpawn;
    public int numberOfPrefabsToCreate;
}