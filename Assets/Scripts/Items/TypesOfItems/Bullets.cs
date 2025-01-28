using UnityEngine;
[CreateAssetMenu(fileName = "New Bullets", menuName = "ItemObjects/Bullets")]
public class Bullets : ItemType
{
    public float bulletDamage;

    public override void OnUse()
    {
        throw new System.NotImplementedException();
    }
}
