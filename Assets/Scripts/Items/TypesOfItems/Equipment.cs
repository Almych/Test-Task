using UnityEngine;

public enum EquipmentType
{
    Head,
    Body,
};

[CreateAssetMenu(fileName ="New Equipment", menuName = "ItemObjects/Equipment")]
public class Equipment : ItemType
{
    public int defendPoints;
    public EquipmentType type;
}
