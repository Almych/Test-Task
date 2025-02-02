using UnityEngine;

public class DamageWay
{
    public EquipmentType hitWay;
    public float damage;
    public DamageWay(EquipmentType hitWay, float damage)
    {
        this.hitWay = hitWay;
        this.damage = damage;
    }
}


