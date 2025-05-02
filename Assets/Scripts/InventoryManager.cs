using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemData itemData;

    public List<Item> itemList = new List<Item>();

    public void AddItem(Item item)
    {
        if(!itemList.Contains(item))
        {
            itemList.Add(item);
            //item.gameObject.SetActive(false);
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(item.itemType), itemList.Count - 1);
        }
    }

}
