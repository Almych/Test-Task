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
    private List<ItemSlot> itemsSlots = new List<ItemSlot>();
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
            itemsSlots.Add(slot);
            inventorySlots[j].AddItem(slot);
        }
    }
    
    public void DecreaseAmount(ItemSlot itemSlot, int decreaseAmount)
    {
        //if (itemSlot.itemObjectData.RemoveItem(decreaseAmount))
        //{
        //    RemoveFromInventory(itemSlot);
        //}
        //itemSlot.UpdateSlot();
    }

    public void IncreaseAmount(ItemSlot itemSlot, int increaseAmount)
    {
        //if (itemSlot.itemObjectData.amount + increaseAmount <= itemSlot.itemObjectData.item.maxStackAmount)
        //{
        //    itemSlot.itemObjectData.AddItem(increaseAmount);
        //    itemSlot.UpdateSlot();
        //}
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

    public bool UseBullets(BulletsType bulletType, int amount)
    {
        int bulletsInInventory = GetBulletsForType(bulletType);

        if (bulletsInInventory >= amount)
        {
            DecreaseBullets(bulletType, amount);
            return true;
        }

        return false;
    }

    private int GetBulletsForType(BulletsType bulletType)
    {
        int amount = 0;
        //for (int i = 0; i < itemsSlots.Count; i++)
        //{
        //    if (itemsSlots[i].itemObjectData.item is Bullets bullet && bullet.bulletsType == bulletType)
        //    {
        //        amount += itemsSlots[i].itemObjectData.amount;
        //    }
        //}
        return amount;
    }

    private void DecreaseBullets(BulletsType bulletType, int amount)
    {
        //for (int i = 0; i < itemsSlots.Count; i++)
        //{
        //    if (itemsSlots[i].itemObjectData.item is Bullets bullet && bullet.bulletsType == bulletType)
        //    {
        //        int decreaseAmount = Mathf.Min(amount, itemsSlots[i].itemObjectData.amount);
        //        DecreaseAmount(itemsSlots[i], decreaseAmount);
        //        amount -= decreaseAmount;

        //        if (amount <= 0) break;
        //    }
        //}
    }
}
