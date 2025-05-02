using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[System.Serializable]
public class Item : MonoBehaviour
{
    //public string ItemName;
    public ItemName itemType;

    public void OnClick()
    {
        InventoryManager.Instance.AddItem(this);
        gameObject.SetActive(false);
    }
}
