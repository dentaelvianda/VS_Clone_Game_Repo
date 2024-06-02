using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
    public class OnHealthChangedEventArgs : EventArgs
    {
        public float healthBar;
        public float maxHealth;
        public float currentHealth;
    }
    
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject dropItemPrefab;
    [SerializeField] private AudioClip deathAudio;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs
        {
            healthBar = 1f,
            currentHealth = currentHealth,
            maxHealth = maxHealth
        });
    }

    public void Hit(float damageAmount)
    {
        currentHealth -= damageAmount;

        OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs
        {
            healthBar = currentHealth / maxHealth,
            currentHealth = currentHealth,
            maxHealth = maxHealth
        });

        if(currentHealth <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                float dropChance = UnityEngine.Random.Range(0f, 1f);

                if (dropChance <= 0.2f) //drop rate 20%
                {
                    Instantiate(dropItemPrefab, transform.position, transform.rotation);
                }
            }
            AudioManager.Instance.PlaySFX(deathAudio, transform.position);
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth(float healthAmount)
    {
        currentHealth += healthAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs
        {
            healthBar = currentHealth / maxHealth,
            currentHealth = currentHealth,
            maxHealth = maxHealth
        });
    }
}
