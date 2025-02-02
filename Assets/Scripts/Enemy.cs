using UnityEngine;

public class Enemy : Character
{
    public static Enemy Instance;
    [SerializeField] private HealthBarUi healthUi;
    [SerializeField] private HealthData health;
    [SerializeField] private float damage;
    private DamageWay previousDamage;
    private HealthBar healthBar;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        healthBar = new HealthBar(health);
    }
    public override void Init()
    {
        healthBar.RestoreOrUpdate();
    }

    public override DamageWay Attack()
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

    public override void Death()
    {
        InventoryManager.Instance.GetRandomLootItem();
       //can hide enemy if dead
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


    public override void GetDamage(DamageWay damageWay)
    {
        healthBar.ChangeHealthValue(-damageWay.damage);
    }
}
