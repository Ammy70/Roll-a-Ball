using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubeRange: MonoBehaviour
{ 

   List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
  // Start is called before the first frame update
   void Start()
    {
        prefabList.Add(Prefab1);
        int prefabIndex = UnityEngine.Random.Range(0,36);
        Instantiate(prefabList[prefabIndex]);

    }

}
