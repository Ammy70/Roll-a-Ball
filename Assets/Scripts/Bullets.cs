using System;
using UnityEngine;
using TMPro;

public class Bullets : MonoBehaviour
{
    public static Action OnBulletHit;
    
    private void OnTriggerEnter(Collider other)
    { 
        if (other.TryGetComponent(out IHealthComponent healthComponent))
        {
            healthComponent.ApplyDamage(10f);
            OnBulletHit?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
    
    



