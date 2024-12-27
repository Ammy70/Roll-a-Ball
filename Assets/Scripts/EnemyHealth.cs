
using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyHealth : MonoBehaviour,IHealthComponent
{
    public float maxHealth = 100;  // Maximum health
    private float currentHealth;  // Current health
    [SerializeField] private bool isPickup;
    [SerializeField] private Image healthImage; // Transform of the health bar's UI element
    private DemageListener damageListener;
    public static Action OnEnemyKilled;
    protected virtual void Start()
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
    protected abstract void Die();

    //OnEnemyKilled?.Invoke();
    //print("Enemy killed");
    //Destroy(gameObject);


    public void ApplyDamage(float value)
    {
        currentHealth -= value;
        float healthPercentage = (float)currentHealth / maxHealth;
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

    public float CheckHealth()
    {
        return currentHealth;
    }


    public bool IsDead() => currentHealth <= 0;



}

