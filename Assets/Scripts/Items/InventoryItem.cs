using System;
using UnityEngine;


[Serializable]
public class InventoryItem
{
    [Range(1, 1000)] public int amount;
    public Item item;

    public InventoryItem(int amount, Item item)
    {
        this.amount = amount;
        this.item = item;
    }
}

