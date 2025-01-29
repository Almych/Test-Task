using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public ItemObject itemObjectData { get; private set; }
    private Transform onDragParent;
    private Image image => GetComponent<Image>();
    private TMP_Text amount => transform.GetChild(0).GetComponent<TMP_Text>();


    public void Init(ItemObject item)
    {
        itemObjectData = item;
        image.sprite = itemObjectData.item.itemSprite;
        UpdateSlot();
    }

   
    public void OnBeginDrag(PointerEventData eventData)
    {
        onDragParent = transform.parent; 
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }



    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; 
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(onDragParent); 
        image.raycastTarget = true;
    }

    

    public void SetParentAfterDrag(Transform parent)
    {
        if (onDragParent != null)
        {
            EquipSlot equipSlot = onDragParent.GetComponent<EquipSlot>();
            if (equipSlot != null)
            {
                equipSlot.UpdateDefenseText();
            }
            onDragParent = parent;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.ShowWindow(this);
    }

    public void UpdateSlot()
    {
        if (itemObjectData.amount > 1)
            amount.text = itemObjectData.amount.ToString();
        else
            amount.text = "";
    }
}
