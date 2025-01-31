
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemObject> items = new List<ItemObject>();
    public bool DecreaseItem(ItemSlot item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemType.GetInstanceID() == item.itemObject.itemType.GetInstanceID())
            {
                if (item.itemObject.itemType is Countable)
                {
                    items[i].amount--;
                    if (items[i].amount <= 0)
                        items.RemoveAt(i);
                    return true;
                }
                else if (item.itemObject.itemType is UnCountable)
                {
                    items.RemoveAt(i);
                    return true;
                }
            }
        }
        return false;
    }

    public void RemoveFromInventory(ItemSlot slot)
    {
        if (items.Contains(slot.itemObject))
        {
            items.Remove(slot.itemObject);
        }
    }

    public void AddItem(ItemObject item)
    {
        if (item.itemType is Countable)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemType.GetInstanceID() == item.itemType.GetInstanceID())
                {
                    items[i].amount++;
                }
                else
                {
                    items.Add(item);
                }
            }
        }
        else if (item.itemType is UnCountable)
        {
            items.Add(item);
        }
    }
}
