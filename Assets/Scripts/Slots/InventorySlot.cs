using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int hasItem => transform.childCount;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject item = eventData.pointerDrag; 
        ItemSlot newItem = item.GetComponent<ItemSlot>();
        AddItem(newItem); 
    }

    public bool AddItem(ItemSlot newItem)
    {
        if (transform.childCount > 0)
        {
            ItemSlot currentItem = transform.GetChild(0).GetComponent<ItemSlot>();
            if (currentItem.inventoryData.item == newItem.inventoryData.item)
            {

                int availableSpace = currentItem.inventoryData.item.maxStackSize - currentItem.inventoryData.amount;
                int amountToAdd = Mathf.Min(newItem.inventoryData.amount, availableSpace);

                InventoryManager.Instance.IncreaseItem(currentItem, amountToAdd);

                InventoryManager.Instance.DeIncreaseItem(newItem, amountToAdd);
                return true;
            }
            return false;
        }
        else
        {
            newItem.SetParentAfterDrag(transform);
            newItem.transform.SetParent(transform);
            return true;
        }
    }

   
}
