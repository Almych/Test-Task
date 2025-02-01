
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemObject> items = new List<ItemObject>();
    public bool DecreaseItem(ItemObject item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemType == item.itemType) 
            {
                if (item.itemType is Countable)
                {
                    items[i].amount--;
                    if (items[i].amount <= 0)
                    {
                        items.RemoveAt(i);
                        return true;
                    }
                }
                else if (item.itemType is UnCountable)
                {
                    items.RemoveAt(i);
                    return true;
                }
            }
        }
        return false;
    }


    public bool RemoveFromInventory(ItemSlot slot)
    {
        if (items.Contains(slot.itemObject))
        {
            items.Remove(slot.itemObject);
            return true;
        }
        return false;
    }

    public void IncreaseItem(ItemObject item, int increaseAmount)
    {
        if (item.itemType is Countable countable)
        {
           
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    if (items[i].amount + increaseAmount <= countable.maxStackAmount)
                    {
                        items[i].amount += increaseAmount;
                        return;  
                    }
                }
                else
                {
                    Debug.Log("no found");
                }
            }
        }
        else
        {

            AddItem(item);
        }
    }




    public void AddItem(ItemObject itemObject)
    {
        items.Add(itemObject);
    }
}
