
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [HideInInspector] public ItemSlot itemSlot;
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
            if (transform.GetChild(0) == null)
            {
                itemSlot = newItem;
                itemSlot.SetParentToItem(transform);
            }
            else
            {
                itemSlot = transform.GetChild(0).GetComponent<ItemSlot>();
                if (itemSlot.itemObjectData.GetInstanceID() == newItem.itemObjectData.GetInstanceID())
                {
                    if (itemSlot.itemObjectData is MassItemObject massItemObject)
                    {
                        if (massItemObject.currentAmount < massItemObject.maxStackAmount)
                            massItemObject.currentAmount++;
                        newItem.gameObject.SetActive(false);
                    }
                }
            }
        }else
        {
            itemSlot = newItem;
            itemSlot.SetParentToItem(transform);
        }
    }
}
