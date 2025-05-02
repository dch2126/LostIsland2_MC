using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button leftBtn, rightBtn;
    public SlotUI slotUI;
    public int curIndex;

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        if (itemDetails == null)
        {
            slotUI.SetEmpty();
            curIndex = -1;
            leftBtn.interactable = false;
            rightBtn.interactable = false;
        }
        else
        {
            curIndex = index;
            slotUI.SetItem(itemDetails);
        }
    }
}
