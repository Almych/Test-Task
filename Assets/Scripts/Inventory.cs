
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct ItemObject
{
    public ItemType item;
    public int amount;
}

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemObject> items = new List<ItemObject>();
    //public bool RemoveItem(ItemObject item)
    //{
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i].item.GetInstanceID() == item.item.GetInstanceID())
    //        {
    //            Debug.Log("REMOVED");
    //            items.RemoveAt(i);
        
    //            Debug.Log($"Items left {items} and length: {items.Count}");
    //            return true;
    //        }
    //    }
    //    return false;
    //}

}
