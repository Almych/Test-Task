using UnityEngine;
using UnityEngine.EventSystems;

public class AimSlot : ItemSlot
{
    public override void Init(InventoryItem inventoryItem)
    {
        base.Init(inventoryItem);
    }
    public override void OnUse()
    {
        Aim aim = inventoryData.item as Aim;
        Player.Instance.Heal(aim.healPoints);
        InventoryManager.Instance.DeIncreaseItem(this, 1);
        UpdateSlot();
    }

    public override void SetParentAfterDrag(Transform parent)
    {
        base.SetParentAfterDrag(parent);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }
}
