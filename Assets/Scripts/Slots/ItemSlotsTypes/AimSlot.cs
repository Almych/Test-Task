using UnityEngine;
using UnityEngine.EventSystems;

public class AimSlot : ItemSlot
{
    
    public override void OnUse()
    {
        Aim aim = itemObject.itemType as Aim;
        Player.Instance.healthBar.ChangeHealthValue(aim.healPoints);
        InventoryManager.Instance.DecreaseAmount(this, 1);
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
