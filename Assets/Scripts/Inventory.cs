
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemObject> items = new List<ItemObject>();
    public void RemoveItem(ItemObject item)
    {
       if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

}
