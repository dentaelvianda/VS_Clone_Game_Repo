using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event EventHandler<OnHealthDecreasedEventArgs> OnHealthDecreased;
    public class OnHealthDecreasedEventArgs : EventArgs
    {
        public float healthBar;
        public float maxHealth;
        public float currentHealth;
    }
    
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        OnHealthDecreased?.Invoke(this, new OnHealthDecreasedEventArgs
        {
            healthBar = 1f,
            currentHealth = currentHealth,
            maxHealth = maxHealth
        });
    }

    public void Hit(float damageAmount)
    {
        currentHealth -= damageAmount;

        OnHealthDecreased?.Invoke(this, new OnHealthDecreasedEventArgs
        {
            healthBar = currentHealth / maxHealth,
            currentHealth = currentHealth,
            maxHealth = maxHealth
        });

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
