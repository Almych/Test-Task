using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public Sprite itemSprite;
    public float itemWeight;

    public abstract void OnUse();
}
