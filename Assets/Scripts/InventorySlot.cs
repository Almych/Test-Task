using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject item = eventData.pointerDrag; 
        ItemSlot newItem = item.GetComponent<ItemSlot>();
        AddItem(newItem); 
    }

    public void AddItem(ItemSlot newItem)
    {
        if (transform.childCount > 0)
        {
            ItemSlot currentItem = transform.GetChild(0).GetComponent<ItemSlot>();
            if (currentItem.itemObjectData.item == newItem.itemObjectData.item && currentItem.itemObjectData.amount < currentItem.itemObjectData.item.maxStackAmount)
            {
                int availableSpace = currentItem.itemObjectData.item.maxStackAmount - currentItem.itemObjectData.amount;
                int amountToAdd = Mathf.Min(newItem.itemObjectData.amount, availableSpace);

                InventoryManager.Instance.IncreaseAmount(currentItem.itemObjectData, amountToAdd);

                InventoryManager.Instance.DecreaseAmount(newItem, amountToAdd);
            }
            
        }
        else
        {
            newItem.SetParentAfterdrag(transform);
            newItem.transform.SetParent(transform);
        }
    }

   
}
