using UnityEngine;

public abstract class ItemType : ScriptableObject
{
    public Sprite itemSprite;
    public float itemWeight;
    [Range(1, 1000)] public int maxStackAmount;
}

