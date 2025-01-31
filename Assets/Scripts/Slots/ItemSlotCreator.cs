using System.Collections.Generic;
using UnityEngine;

public class ItemSlotCreator : MonoBehaviour
{
    [SerializeField] private GameObject itemSlotPrefab;
   
    public ItemSlot CreateItemSlot(ItemObject item)
    {
        ItemSlot slot = Instantiate(itemSlotPrefab).GetComponent<ItemSlot>();
        slot.Init(item);
        return slot;
    }
}
