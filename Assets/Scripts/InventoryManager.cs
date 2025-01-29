using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Inventory inventory;
    public ItemSlotCreator inventorySlotCreator;
    public List<InventorySlot> inventorySlots;
    public PopupWindow popupWindow;
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
    
    public void DecreaseAmount(ItemSlot itemSlot, int decreaseAmount)
    {

        if (itemSlot.itemObjectData.RemoveItem(decreaseAmount))
        {
            RemoveFromInventory(itemSlot);
        }
        itemSlot.UpdateSlot();
    }

    public void IncreaseAmount(ItemSlot itemSlot, int increaseAmount)
    {
        if (itemSlot.itemObjectData.amount + increaseAmount <= itemSlot.itemObjectData.item.maxStackAmount)
        {
            itemSlot.itemObjectData.AddItem(increaseAmount);
            itemSlot.UpdateSlot();
        }
    }

    public void RemoveFromInventory(ItemSlot itemSlot)
    {
        if(inventory.RemoveItem(itemSlot.itemObjectData))
        Destroy(itemSlot.gameObject);
    }
    public void ShowWindow(ItemSlot slot)
    {
        popupWindow.gameObject.SetActive(true);
        popupWindow.ShowWindow(slot);
    }
}
