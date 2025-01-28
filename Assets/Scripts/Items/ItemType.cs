using UnityEngine;

public abstract class ItemType : ScriptableObject
{
    public Sprite itemSprite;
    public float itemWeight;
    public int maxStackAmount;
    public abstract void OnUse();
}

