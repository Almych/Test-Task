using System;
using UnityEngine;
[Serializable]
public class ItemObject
{
    public ItemType item;
    public int amount;

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
