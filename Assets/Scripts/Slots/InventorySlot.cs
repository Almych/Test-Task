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
            if (currentItem.itemObject.itemType.GetInstanceID() == newItem.itemObject.itemType.GetInstanceID() && currentItem.itemObject.itemType is Countable currentType && newItem.itemObject.itemType is Countable) //currentItem.itemObjectData.amount < currentItem.itemObjectData.item.maxStackAmount
            {
                
                int availableSpace = currentType.maxStackAmount - currentItem.itemObject.amount;
                int amountToAdd = Mathf.Min(newItem.itemObject.amount, availableSpace);

                InventoryManager.Instance.IncreaseAmount(currentItem, amountToAdd);

                InventoryManager.Instance.DecreaseAmount(newItem, amountToAdd);

            }
            
        }
        else
        {
            newItem.SetParentAfterDrag(transform);
            newItem.transform.SetParent(transform);
        }
    }

   
}
