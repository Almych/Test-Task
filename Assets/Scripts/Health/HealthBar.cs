using System;
using UnityEngine;

public class HealthBar 
{
    public event Action OnDeath;
    public delegate void HealthChange(float health, float maxHealth);
    public event HealthChange OnHealthValueChanged;
    private HealthData healthData;
    public float CurrentHealth
    {
        get => healthData.currentHealth;
        private set
        {
            healthData.currentHealth = Mathf.Clamp(value, 0f, healthData.maxHealth);
           UpdateHealthBar();
        }
    }

    public HealthBar(HealthData healthData)
    {
        this.healthData = healthData;
    }

    public void RestoreOrUpdate()
    {
        if (healthData.currentHealth <= 0f)
            ChangeHealthValue(healthData.maxHealth);
        else
            UpdateHealthBar();
    }

    public void ChangeHealthValue(float value)
    {
        CurrentHealth += value;
        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    private void UpdateHealthBar()
    {
        OnHealthValueChanged?.Invoke(healthData.currentHealth, healthData.maxHealth);
    }
   

}
