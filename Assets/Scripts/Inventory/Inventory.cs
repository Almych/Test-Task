using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemObject
{
    public int amount;
    public Item item;
}

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();


    public void IncreaseAmount(InventoryItem inventoryItem, int quantity)
    {
        if (inventoryItem.item.isStackable)
        {
            if (inventoryItem.amount + quantity <= inventoryItem.item.maxStackSize)
            {
                inventoryItem.amount += quantity;
            }
        }
    }

    public bool DeIncreaseAmount(InventoryItem inventoryItem, int quantity)
    {
        if (inventoryItem.item.isStackable)
        {
           
            inventoryItem.amount -= quantity;
            if (inventoryItem.amount <= 0)
            {
                inventoryItems.Remove(inventoryItem);
                return true;
            }
        }
        else
        {
            inventoryItems.Remove(inventoryItem);
            return true;
        }
        return false;
    }

    public bool RemoveFromInventory(InventoryItem item)
    {
        InventoryItem findItem = FindInventorySlot(item);
        if (findItem != null)
        {
            inventoryItems.Remove(findItem);
            return true;
        }
        return false; 
    }

    public InventoryItem FindInventorySlot(InventoryItem item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i] == item)
            {
                return inventoryItems[i];
            }
        }
        return null;
    }
}
