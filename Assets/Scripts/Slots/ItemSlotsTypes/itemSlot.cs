using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public abstract class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public ItemObject itemObject { get; private set; }
    protected Transform onDragParent;
    protected Image image => GetComponent<Image>();
    protected TMP_Text amount => transform.GetChild(0).GetComponent<TMP_Text>();


    public void Init(ItemObject item)
    {
        itemObject = item;
        image.sprite = item.itemType.itemSprite;
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

    

    public virtual void SetParentAfterDrag(Transform parent)
    {
       onDragParent = parent;
    }


    public virtual void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.ShowWindow(this);
    }

    public void UpdateSlot()
    {
        if (itemObject.amount > 1)
            amount.text = itemObject.amount.ToString();
        else
            amount.text = "";
    }

    public Transform GetOnDragParent()
    {
        return onDragParent;
    }

    public abstract void OnUse();
}
