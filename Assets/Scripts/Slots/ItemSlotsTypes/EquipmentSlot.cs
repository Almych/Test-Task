using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : ItemSlot
{

    public override void OnUse()
    {
       
    }

    public override void SetParentAfterDrag(Transform parent)
    {
        if (onDragParent != null)
        {
            EquipSlot equipSlot = onDragParent.GetComponent<EquipSlot>();
            if (equipSlot != null)
            {
                equipSlot.UpdateDefenseText();
            }
        }

        base.SetParentAfterDrag(parent);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onDragParent == null || onDragParent.GetComponent<EquipSlot>() == null )
            InventoryManager.Instance.ShowWindow(this);
    }
}
