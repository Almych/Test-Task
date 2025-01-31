using System;
using UnityEngine;


[Serializable]
public class ItemObject
{
    [Range(1, 1000)] public int amount;
    public ItemType itemType;
}
