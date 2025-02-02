using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private Inventory inventory;
    [SerializeField] private ItemSlotCreator inventorySlotCreator;
    [SerializeField] private List<InventorySlot> inventorySlots;
    [SerializeField] private PopupWindow popupWindow;
    private List<ItemSlot> itemsSlots = new List<ItemSlot>();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Init()
    {
        for (int i = 0; i < inventorySlots.Count && i < inventory.inventoryItems.Count; i++)
        {
            CreateInventorySlot(inventory.inventoryItems[i]);
        }
    }

    public void IncreaseItem(ItemSlot slot, int amount)
    {
        inventory.IncreaseAmount(slot.inventoryData, amount);
    }
    
    public void DeIncreaseItem(ItemSlot slot, int amount)
    {
        if (inventory.DeIncreaseAmount(slot.inventoryData, amount))
        {
            itemsSlots.Remove(slot);
            Destroy(slot.gameObject);
        }

    }

    public void RemoveFromInventory(ItemSlot slot)
    {
        if(inventory.RemoveFromInventory(slot.inventoryData))
        Destroy(slot.gameObject);
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
        int totalBulletAmount = 0;

        for (int i = 0; i < inventory.inventoryItems.Count; i++)
        {
            if (inventory.inventoryItems[i].item is Bullets bullet)
            {

                if (bullet.bulletsType == bulletType)
                {
                    if (bullet != null)
                    {
                        totalBulletAmount += inventory.inventoryItems[i].amount;
                    }
                }
               
            }
        }
        return totalBulletAmount;
    }


    private void DecreaseBullets(BulletsType bulletType, int amount)
    {
        int remainingAmount = amount;

        for (int i = 0; i < itemsSlots.Count && remainingAmount > 0; i++)
        {
            if (itemsSlots[i] is BulletsSlot bulletsSlot && bulletsSlot.bulletsType == bulletType)
            {
                int availableInSlot = itemsSlots[i].inventoryData.amount;
              
                if (availableInSlot <= remainingAmount)
                {
                    remainingAmount -= availableInSlot;
                    DeIncreaseItem(itemsSlots[i], availableInSlot);
                }
                else
                {

                    DeIncreaseItem(itemsSlots[i], remainingAmount);
                    remainingAmount = 0;
                }
                itemsSlots[i].UpdateSlot();
                break;
            }
        }

   
    }


    public void CreateInventorySlot(InventoryItem inventoryItem)
    {
        if(inventoryItem.amount > inventoryItem.item.maxStackSize)
        {
            inventoryItem.amount = inventoryItem.item.maxStackSize;
        }
        ItemSlot itemSlot = inventorySlotCreator.CreateItemSlot(inventoryItem);
        GetFreeSlot(itemSlot);
    }

    private void GetFreeSlot(ItemSlot itemSlot)
    {
        for(int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].hasItem == 0)
            {
                inventorySlots[i].AddItem(itemSlot);
                itemSlot.UpdateSlot();
                itemsSlots.Add(itemSlot);
            }
               
        }
      
    }


    //Gets random items from inventory and creates new one like loot
    public void GetRandomLootItem()
    {
        int index = Random.Range(0, inventory.inventoryItems.Count);
        InventoryItem loot = new InventoryItem(1, inventory.inventoryItems[index].item);
        inventory.inventoryItems.Add(loot);
        CreateInventorySlot(loot);
    }
}
