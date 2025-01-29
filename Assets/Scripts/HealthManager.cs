using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public HealthData healthData;
    public HealthBarUi healthBarUi;
    public HealthBar healthBar;
    private void Awake()
    {
        healthBar = new HealthBar(healthData);
    }

    private void Start()
    {
        healthBar.RestoreHealth();
    }

    private void OnEnable()
    {
        healthBar.OnHealthValueChanged += healthBarUi.ChangeValue;
    }

    private void OnDisable()
    {
        healthBar.OnHealthValueChanged -= healthBarUi.ChangeValue;
    }

    public void Heal(float health)
    {
        healthBar.ChangeHealthValue(health);
    }

    public void GetDamage(float damage)
    {
        healthBar.ChangeHealthValue(-damage);
    }
   
}
