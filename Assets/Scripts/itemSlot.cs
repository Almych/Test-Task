using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public ItemObject itemObjectData;
    private Transform onDragParent;
    private Image image => GetComponent<Image>();
   

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

    public void SetParentToItem(Transform parent)
    {
        onDragParent = parent;
    }
}
