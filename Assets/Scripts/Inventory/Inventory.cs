
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
            if (items[i] == item)
            {
                items.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

}
