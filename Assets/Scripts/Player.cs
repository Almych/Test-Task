using UnityEngine;

public class Player : Character
{
    public static Player Instance;
    [SerializeField] private HealthData health;
    [SerializeField] private HealthBarUi healthUi;
    [SerializeField] private EquipSlot headSlot, bodySlot;
    private HealthBar healthBar;
    private WeaponManager weaponManager => GetComponent<WeaponManager>();
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        healthBar = new HealthBar(health);
    }

    public override void Init()
    {
        healthBar.RestoreOrUpdate();
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

    public void Heal(float healPoints)
    {
        healthBar.ChangeHealthValue(healPoints);
    }

    public override DamageWay Attack()
    {
        return new DamageWay(EquipmentType.Head, weaponManager.Shoot());
    }


    public override void Death()
    {
        GameManager.Instance.ShowGameOverWindow();
    }

    public override void GetDamage(DamageWay damageWay)
    {
        if (Defense(damageWay) >= 0)
        {
            healthBar.ChangeHealthValue(0f);
        }
        else
        {
            healthBar.ChangeHealthValue(Defense(damageWay));
        }
    }

    private float Defense(DamageWay damageWay)
    {
        if (damageWay.hitWay == EquipmentType.Head)
        {
           return headSlot.GetDefensePoints() - damageWay.damage;
        }
        else
        {
            return bodySlot.GetDefensePoints() - damageWay.damage;
        }
    }

    public void PutOnArmor(EquipmentSlot slot, EquipmentType equipmentType)
    {
        if (equipmentType == EquipmentType.Body)
        {
            bodySlot.Equip(slot);
        }
        else
        {
            headSlot.Equip(slot);
        }
    }
}
