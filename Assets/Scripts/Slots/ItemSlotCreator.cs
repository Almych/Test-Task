using System.Collections.Generic;
using UnityEngine;

public class ItemSlotCreator : MonoBehaviour
{
    [SerializeField] private GameObject itemSlotPrefab;
    private ItemSlot slot;
    public ItemSlot CreateItemSlot(ItemObject item)
    {
       
        switch(item.itemType)
        {
            case Equipment:
                slot = Instantiate(itemSlotPrefab).AddComponent<EquipmentSlot>();
                break;
            case Bullets:
                slot = Instantiate(itemSlotPrefab).AddComponent<BulletsSlot>();
                break;
            case Aim:
                slot = Instantiate(itemSlotPrefab).AddComponent<AimSlot>();
                break;
            default:
                break;

        }
        if (slot != null)
        slot.Init(item);
        return slot;
    }
}
