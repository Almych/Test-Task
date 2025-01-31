using UnityEngine;
using UnityEngine.EventSystems;

public class BulletsSlot : ItemSlot
{
    public override void OnUse()
    {
       
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
