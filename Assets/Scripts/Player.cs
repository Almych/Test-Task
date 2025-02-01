using UnityEngine;

public class Player : MonoBehaviour, IAttackHandler, IDeathHandler, IGetDamageHandler
{
    public static Player Instance;
    [SerializeField] private HealthData health;
    [SerializeField] private HealthBarUi healthUi;
    [SerializeField] private EquipSlot headSlot, bodySlot;
    public HealthBar healthBar { get; private set; }
    private WeaponManager weaponManager => GetComponent<WeaponManager>();
    void Awake()
    {
        if (Instance == null)
            Instance = this;
       healthBar = new HealthBar(health);
    }
    private void Start()
    {
        if(healthBar.CurrentHealth <= 0)
        healthBar.RestoreHealth();
        else healthBar.UpdatehealthBar();
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


    public DamageWay Attack()
    {
        return new DamageWay(EquipmentType.Head, weaponManager.Shoot());
    }

    public void Death()
    {
        GameManager.Instance.ShowGameOverWindow();
    }

    public void GetDamage(DamageWay damageWay)
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
}
