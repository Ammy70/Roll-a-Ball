using System;
using UnityEngine;
using TMPro;

public class Bullets : MonoBehaviour
{
    public static Action OnBulletHit;
    private void OnTriggerEnter(Collider other)
    { 
        // Check for a specific tag
        if (other.gameObject.CompareTag("PickUp"))
        {
            EnemyHealthbar enemyHealth = other.GetComponent<EnemyHealthbar>();
            if (enemyHealth != null)
            {
                print("enemy health" + other.gameObject.name);
                enemyHealth.TakeDamage(10); // Example damage value
                OnBulletHit?.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}
    
    



