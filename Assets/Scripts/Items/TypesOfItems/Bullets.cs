using UnityEngine;
public enum BulletsType {
    HeavyGun,
    LightGun,
};

[CreateAssetMenu(fileName = "New Bullets", menuName = "ItemObjects/Bullets")]
public class Bullets : ItemType
{
    public float bulletDamage;
    public BulletsType bulletsType;

    public override void OnUse()
    {
        throw new System.NotImplementedException();
    }
}
