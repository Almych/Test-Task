using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Inventory inventory;
    public ItemSlotCreator inventorySlotCreator;
    public List<InventorySlot> inventorySlots;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        for (int j = 0; j < inventorySlots.Count && j < inventory.items.Count; j++)
        {
            ItemSlot slot = inventorySlotCreator.CreateItemSlot(inventory.items[j]);
            inventorySlots[j].AddItem(slot);
        }
    }

    public void DecreaseAmount(ItemSlot item, int decreaseAmount)
    {
        item.itemObjectData.amount -= decreaseAmount;

        if (item.itemObjectData.amount <= 0)
        {
            
        }
    }

    public void IncreaseAmount(ItemObject itemObject, int increaseAmount)
    {
        if (itemObject.amount + increaseAmount <= itemObject.item.maxStackAmount)
            itemObject.amount += increaseAmount;
    }
}
