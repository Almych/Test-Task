using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthData healthData;
    public event Action OnDeath;

    void Start()
    {
        
    }

    public void InitHealth()
    {
        if (healthData.currentHealth <= 0)
        {
            healthData.currentHealth = healthData.maxHealth;
        }
    }
}
