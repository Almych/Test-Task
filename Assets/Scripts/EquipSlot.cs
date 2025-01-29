using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipSlot : MonoBehaviour, IDropHandler
{
    public EquipmentType equipmentType;
    public TMP_Text defenseText;
    private ItemSlot currentItem;
    public void OnDrop(PointerEventData eventData)
    {
       ItemSlot slot = eventData.pointerDrag.GetComponent<ItemSlot>();
        if (slot != null)
            Equip(slot);
    }

    public void Equip(ItemSlot equipmentSlot)
    {
        if(transform.childCount > 0)
        currentItem = transform.GetChild(0).GetComponent<ItemSlot>();
        if (equipmentSlot.itemObjectData.item is Equipment equipment && equipment.type == equipmentType)
        {
            if(currentItem != null)
            {
                currentItem.SetParentAfterDrag(equipmentSlot.transform.parent);
                currentItem.transform.SetParent(equipmentSlot.transform.parent);
            }
            equipmentSlot.SetParentAfterDrag(transform);
            equipmentSlot.transform.SetParent(transform);
            equipmentSlot.transform.SetAsFirstSibling();
            currentItem = equipmentSlot;
            defenseText.text = $"+ {equipment.defendPoints.ToString()}";
        }
    }

   

    public void UpdateDefenseText()
    {
        var equipment = currentItem.itemObjectData.item as Equipment;
        if (equipment != null)
        {
            defenseText.text = "0";
        }
    }
}

