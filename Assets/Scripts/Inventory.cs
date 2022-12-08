using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Inventory
{
    [SerializeField] List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item newItem)
    {
        itemList.Add(newItem);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item itemToRemove)
    {
        itemList.Remove(itemToRemove);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public void ClearInventory()
    {
        itemList.Clear();
    }

    //public bool ListContainsObject(Item item)
    //{
    //    return itemList.Contains(item);
    //}
}
