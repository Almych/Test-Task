using UnityEngine;

public enum EquipmentType
{
    Head,
    Body,
};

[CreateAssetMenu(fileName ="New Equipment", menuName = "ItemObjects/Equipment")]
public class Equip : ItemType
{
    public int defendPoints;
    public EquipmentType type;

    public override void OnUse()
    {
        throw new System.NotImplementedException();
    }
}
