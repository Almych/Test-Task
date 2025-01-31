using UnityEngine;
public enum BulletsType {
    HeavyGun,
    LightGun,
};

[CreateAssetMenu(fileName = "New Bullets", menuName = "ItemType/Bullets")]
public class Bullets : Countable
{
    public BulletsType bulletsType;
}
