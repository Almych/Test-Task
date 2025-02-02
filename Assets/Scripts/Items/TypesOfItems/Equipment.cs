using UnityEngine;

public enum EquipmentType
{
    Head,
    Body,
};

[CreateAssetMenu(fileName ="New Equipment", menuName = "ItemType/Equipment")]
public class Equipment : Item
{
    public int defendPoints;
    public EquipmentType type;
}
