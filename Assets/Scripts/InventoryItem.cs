using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Item thisItem;

    public void SetItem()
    {
        FindObjectOfType<ClothesChange>().EquipItem(thisItem);
    }
}
