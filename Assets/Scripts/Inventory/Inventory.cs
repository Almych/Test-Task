
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemObject> items = new List<ItemObject>();
    public bool RemoveItem(ItemObject item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (item is CountableObject countableItemObject)
            {
                countableItemObject.amount--;
                if (countableItemObject.amount < 0)
                return true;
            }
            else if (item is UnCountableObject unCountableItem) 
            {
                items.RemoveAt(i);
            }
        }
        return false;
    }


    public void AddItem(ItemObject item)
    {
        if (item is CountableObject countableItemObject)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemType.GetInstanceID() == countableItemObject.itemType.GetInstanceID())
                {
                    CountableObject findItem = items[i] as CountableObject;
                    findItem.amount++;
                }
                else
                {
                    items.Add(item);
                }
            }
        }
        else if (item is UnCountableObject unCountableItem)
        {
            items.Add(item);
        }
    }
}
