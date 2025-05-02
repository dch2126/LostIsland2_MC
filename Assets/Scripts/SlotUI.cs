using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemImage;
    private ItemDetails curItem;
    private bool isSelected = false;

    public void SetItem(ItemDetails itemDetails)
    {
        curItem = itemDetails;
        gameObject.SetActive(true);
        itemImage.sprite = itemDetails.itemSprite;
        itemImage.SetNativeSize();
    }

    public void SetEmpty()
    {
        //curItem = null;
        gameObject.SetActive(false);
        //itemImage.sprite = null;
    }
}
