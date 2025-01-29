using System;
using UnityEngine;
[Serializable]
public class ItemObject
{
    public ItemType item;
    [Range(1,1000)]public int amount;

    public void AddItem(int addAmount)
    {
        amount += addAmount;
    }

    public bool RemoveItem(int removeAmount)
    {
        amount -= removeAmount;
        if (amount <=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
