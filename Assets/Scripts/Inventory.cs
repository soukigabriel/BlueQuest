using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [SerializeField] List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item newItem)
    {
        itemList.Add(newItem);
    }

    public void RemoveItem(Item itemToRemove)
    {
        itemList.Remove(itemToRemove);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
