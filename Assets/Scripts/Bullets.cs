using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullets : MonoBehaviour
{
    public float life = 3;
    public static int enemyCount = 0;
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Log the name of the object we collided with
        Debug.Log("Collided with: " + other.gameObject.name);
        // Check for a specific tag
        if (other.gameObject.CompareTag("PickUp"))
        {
            enemyCount++;
            Debug.Log("Enemies Hit: " + enemyCount);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
    
    



