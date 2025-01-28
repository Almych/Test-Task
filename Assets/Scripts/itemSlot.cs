using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public ItemObject itemObjectData { get; private set; }
    private Transform onDragParent;
    private Image image => GetComponent<Image>();


    public void Init(ItemObject item)
    {
        itemObjectData = item;
        image.sprite = itemObjectData.item.itemSprite;
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
        onDragParent = parent;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.ShowWindow(this);
    }
}
