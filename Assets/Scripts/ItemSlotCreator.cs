using System.Collections.Generic;
using UnityEngine;

public class ItemSlotCreator : MonoBehaviour
{
    [SerializeField] private GameObject itemSlotPrefab;

    // Создаем слоты на основе данных из инвентаря
    public ItemSlot CreateItemSlot(ItemObject item)
    {
        ItemSlot slot = Instantiate(itemSlotPrefab).GetComponent<ItemSlot>();
        slot.Init(item);
        return slot;
    }
}
