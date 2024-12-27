using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : EnemyHealth
{
    protected override void Die()
    {
        Destroy(gameObject);
    }

    
}
