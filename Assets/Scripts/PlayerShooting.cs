using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private int weaponDamage = 20;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IHealthComponent health = hit.collider.GetComponent<IHealthComponent>();
                if (health != null)
                {
                    health.ApplyDamage(weaponDamage);
                }
            }
        }
    }
}
