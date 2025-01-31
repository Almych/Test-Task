using UnityEngine;
using UnityEngine.EventSystems;

public class AimSlot : ItemSlot
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
