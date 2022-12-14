using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shop
{
    [SerializeField] List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public Shop()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item newItem)
    {
        itemList.Add(newItem);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
