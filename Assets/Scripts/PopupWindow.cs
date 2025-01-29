using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    public Image imageOfItem;
    public TMP_Text weightCount;
    public TMP_Text nameOfItem;
    public TMP_Text uniqIconText;
    public Image uniqIcon;
    public ItemsIcons icons;
    public Button useButton, deleteButton;


    public void ShowWindow(ItemSlot itemSlot)
    {
        imageOfItem.sprite = itemSlot.itemObjectData.item.itemSprite;
        weightCount.text = itemSlot.itemObjectData.item.itemWeight.ToString() + " кг";
        nameOfItem.text = itemSlot.itemObjectData.item.name;
        useButton.onClick.AddListener(itemSlot.itemObjectData.item.OnUse);
        deleteButton.onClick.AddListener(() => InventoryManager.Instance.RemoveFromInventory(itemSlot));
        TMP_Text useButtonText = useButton.transform.GetChild(0).GetComponent<TMP_Text>();
        if (useButtonText != null)
        {
            ItemType itemType = itemSlot.itemObjectData.item;
            if (itemType is Bullets)
            {
                useButtonText.text = " упить";
                uniqIcon.sprite = icons.bulletIcon;
            }
            else if (itemType is Aim)
            {
                useButtonText.text = "Ћечить";
                uniqIcon.sprite = icons.healIcon;
            }
            else if (itemType is Equipment)
            {
                useButtonText.text = "Ёкипировать";
                uniqIcon.sprite = icons.defenseIcon;
            }
        }
    }

    
}
