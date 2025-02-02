using UnityEngine;

public abstract class Item : ScriptableObject
{
    public Sprite itemSprite;
    public float itemWeight;
    public string itemName;
    [Range(1, 1000)]public int maxStackSize;
    public bool isStackable;
}

