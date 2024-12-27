
using UnityEngine;

public class ExplodingEnemy : EnemyHealth
{
    [SerializeField] private GameObject explosionEffectPrefab;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int explosionDamage = 50;
    [SerializeField] private ParticleSystem ParticleSystem;

    protected override void Die()
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        // Instantiate explosion effect
        if (explosionEffectPrefab != null)
        {
           GameObject explosion =Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            if (ParticleSystem != null)
            {
                Destroy(explosion, ParticleSystem.main.duration);
            }


        }
       
        // Damage nearby objects
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in hitColliders)
        {
            IHealthComponent target = hit.GetComponent<IHealthComponent>();
            if (target != null && !target.IsDead())
            {
                target.ApplyDamage(explosionDamage);
               
            }
        }

        Debug.Log("Exploding Cube Enemy exploded.");
    }
}


    