using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipSlot : MonoBehaviour, IDropHandler
{
    public EquipmentType equipmentType;
    public TMP_Text defenseText;
    private int defensePoint;
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
        if (equipmentSlot.itemObject.itemType is Equipment equipment && equipment.type == equipmentType)
        {
            if(currentItem != null)
            {
                currentItem.transform.position = equipmentSlot.GetOnDragParent().position;
                currentItem.transform.SetParent(equipmentSlot.GetOnDragParent());
                currentItem.SetParentAfterDrag(equipmentSlot.GetOnDragParent());
            }
            defensePoint = equipment.defendPoints;
            equipmentSlot.SetParentAfterDrag(transform);
            equipmentSlot.transform.SetParent(transform);
            equipmentSlot.transform.SetAsFirstSibling();
            currentItem = equipmentSlot;
            defenseText.text = $"+ {equipment.defendPoints.ToString()}";
        }
    }



    public void UpdateDefenseText()
    {
        var equipment = currentItem.itemObject.itemType as Equipment;
        if (equipment != null)
        {
            defenseText.text = "0";
        }
    }

    public int GetDefensePoints()
    {
        return defensePoint;
    }
}

