using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//public enum ItemType { HatOne, HatTwo, ClothesOne, ClothesTwo, SwordOne, SwordTwo}
public class ShopItem : MonoBehaviour
{
    public Item thisItem;

    public void SendCurrentItemToManager()
    {
        FindObjectOfType<UIManager>().SetCurrentSelectedObject(thisItem, this.gameObject);
    }
}
