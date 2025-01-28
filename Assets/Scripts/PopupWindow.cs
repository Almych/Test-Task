using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    public Image imageOfItem;
    public TMP_Text weightCount;
    public TMP_Text nameOfItem;
    public TMP_Text uniqThingCount;
    public Image uniqImageData;
    public ItemsIcons icons;
    public Button useItem, deleteItem;
    public  void ShowWindow(ItemSlot item)
    {
        imageOfItem.sprite = item.itemObjectData.item.itemSprite;
        weightCount.text = item.itemObjectData.item.itemWeight.ToString() + " кг";
        nameOfItem.text = item.itemObjectData.item.name;
        useItem.onClick.AddListener(item.itemObjectData.item.OnUse);
        deleteItem.onClick.AddListener(() => InventoryManager.Instance.RemoveFromInventory(item));
        deleteItem.transform.GetChild(0).GetComponent<TMP_Text>().text = "Удалить";
        if (item.itemObjectData.item is Bullets)
        {
            useItem.transform.GetChild(0).GetComponent<TMP_Text>().text = "Купить";
            uniqImageData.sprite = icons.bulletIcon;
        }
        else if (item.itemObjectData.item is Aim)
        {
            useItem.transform.GetChild(0).GetComponent<TMP_Text>().text = "Лечить";
            uniqImageData.sprite = icons.healIcon;
        }
        else
        {
            useItem.transform.GetChild(0).GetComponent<TMP_Text>().text = "Надеть";
            uniqImageData.sprite = icons.defenseIcon;
        }
    }
}
