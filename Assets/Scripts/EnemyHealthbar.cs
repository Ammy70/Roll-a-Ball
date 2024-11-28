using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health
    private int currentHealth;  // Current health
    [SerializeField] private bool isPickup;
    [SerializeField] private Image healthImage; // Transform of the health bar's UI element
    private DemageListener damageListener;
    public static Action OnEnemyKilled;
    void Start()
    {
        currentHealth = maxHealth;
        if (isPickup)
        {
            damageListener = FindObjectOfType<DemageListener>();
            if (damageListener == null)
            {
                Debug.LogError("deamgeLisnter not found in the scene!");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float healthPercentage = (float) currentHealth / maxHealth;
        if (isPickup && damageListener != null)
        {
            damageListener.UpdateHealthBar(healthPercentage);
        }
        else
        {
            UpdateHealthBar();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void UpdateHealthBar()
    {
        if (healthImage != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            healthImage.fillAmount = healthPercentage;
        }
        else
        {
            Debug.LogWarning("Health Image is not assigned!");
        }
    }
    void Die()
    {
        OnEnemyKilled?.Invoke();
        print("Enemy killed");
        Destroy(gameObject);
    }
}

