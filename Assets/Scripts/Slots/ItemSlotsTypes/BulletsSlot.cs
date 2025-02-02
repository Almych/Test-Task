using UnityEngine;
using UnityEngine.EventSystems;

public class BulletsSlot : ItemSlot
{
    public BulletsType bulletsType { get; private set; }

    public override void Init(InventoryItem inventoryItem)
    {
        base.Init(inventoryItem);
        Bullets bullet = inventoryData.item as Bullets;
        bulletsType = bullet.bulletsType;
    }
    public override void OnUse()
    {
        InventoryManager.Instance.IncreaseItem(this, 1);
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
