using System.Collections.Generic;
using UnityEngine;

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
            slot.UpdateSlot();
            itemsSlots.Add(slot);
            inventorySlots[j].AddItem(slot);
        }
    }
    
    public void DecreaseAmount(ItemSlot itemSlot, int decreaseAmount)
    {
        if (inventory.DecreaseItem(itemSlot))
            Destroy(itemSlot.gameObject);
            itemSlot.UpdateSlot();
    }

    public void RemoveFromInventory(ItemSlot slot)
    {
        inventory.RemoveFromInventory(slot);
    }

    public void IncreaseAmount(ItemSlot itemSlot, int increaseAmount)
    {
        if (itemSlot.itemObject.itemType is Countable countable && itemSlot.itemObject.amount + increaseAmount <= countable.maxStackAmount)
        {
            inventory.AddItem(itemSlot.itemObject);
            itemSlot.UpdateSlot();
        }
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
        for (int i = 0; i < itemsSlots.Count; i++)
        {
            if (itemsSlots[i].itemObject.itemType is Bullets bullet && bullet.bulletsType == bulletType)
            {
                amount += itemsSlots[i].itemObject.amount;
            }
        }
        return amount;
    }

    private void DecreaseBullets(BulletsType bulletType, int amount)
    {
        for (int i = 0; i < itemsSlots.Count; i++)
        {
            if (itemsSlots[i].itemObject.itemType is Bullets bullet && bullet.bulletsType == bulletType)
            {
                int decreaseAmount = Mathf.Min(amount, itemsSlots[i].itemObject.amount);
                DecreaseAmount(itemsSlots[i], decreaseAmount);
                amount -= decreaseAmount;

                if (amount <= 0) break;
            }
        }
    }
}
