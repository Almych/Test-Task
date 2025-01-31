using System;
using UnityEngine;
[CreateAssetMenu(menuName = "ItemObject/Countable", fileName = "new CountableObject")]
public class CountableObject : ItemObject
{
    [Range(1,1000)]public int amount;
    public new ItemType itemType = new UnCountable();
}

[CreateAssetMenu(menuName = "ItemObject/UnCountable", fileName = "new UnCountableObject")]
public class UnCountableObject : ItemObject
{
    public new ItemType itemType = new UnCountable();
}

public abstract class ItemObject : ScriptableObject
{
    public ItemType itemType;
}
