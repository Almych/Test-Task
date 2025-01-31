using UnityEngine;

public enum EquipmentType
{
    Head,
    Body,
};

[CreateAssetMenu(fileName ="New Equipment", menuName = "ItemObjects/Equipment")]
public class Equipment : UnCountable
{
    public int defendPoints;
    public EquipmentType type;
}
