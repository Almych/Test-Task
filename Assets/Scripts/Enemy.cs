using UnityEngine;

public class Enemy : MonoBehaviour, IAttackHandler, IDeathHandler, IGetDamageHandler
{
    [SerializeField] private HealthBarUi healthUi;
    [SerializeField] private HealthData health;
    [SerializeField] private float damage;
    private DamageWay previousDamage;
    private HealthBar healthBar;
    private void Start()
    {
        healthBar = new HealthBar(health);
    }

    public DamageWay Attack()
    {
        if (previousDamage == null || previousDamage.hitWay == EquipmentType.Body)
        {
            DamageWay newDamage = new DamageWay(EquipmentType.Head, damage);
            previousDamage = newDamage;
            return newDamage;
        }
        else
        {
            DamageWay newDamage = new DamageWay(EquipmentType.Body, damage);
            previousDamage = newDamage;
            return newDamage;
        }
       
    }

    public void Death()
    {
       
    }

    private void OnEnable()
    {
        healthBar.OnHealthValueChanged += healthUi.ChangeValue;
        healthBar.OnDeath += Death;
    }

    private void OnDisable()
    {
        healthBar.OnHealthValueChanged -= healthUi.ChangeValue;
        healthBar.OnDeath -= Death;
    }


    public void GetDamage(DamageWay damageWay)
    {
        healthBar.ChangeHealthValue(-damageWay.damage);
    }
}
