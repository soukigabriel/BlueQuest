using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{


    [SerializeField] List<Item> itemList;
    public Shop()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item newItem)
    {
        itemList.Add(newItem);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
