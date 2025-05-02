using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public List<ItemDetails> itemDetailsList;

    public ItemDetails GetItemDetails(ItemName itemName)
    {
        return itemDetailsList.Find(item => item.itemType == itemName);
    }

}

[System.Serializable]
public class ItemDetails
{
    public ItemName itemType;
    public Sprite itemImage;
    public string ItemDescription ="";
}