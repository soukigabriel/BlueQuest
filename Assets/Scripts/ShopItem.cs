using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemType { HatOne, HatTwo, ClothesOne, ClothesTwo, SwordOne, SwordTwo}
public class ShopItem : MonoBehaviour
{
    public ItemType currentItemType;
    public bool haveBeenSold;
    [SerializeField] int price;
    public GameObject myPriceObject;
    public GameObject mySoldObject;
    public TMP_Text priceText;
    public GameObject m_InventoryItem;

    public bool HaveBeenSold
    {
        get => haveBeenSold;
        set
        {
            haveBeenSold = value;
            if(value == true)
            {
                m_InventoryItem.SetActive(true);
            }
            else
            {
                m_InventoryItem.SetActive(false);
            }
        }
    }

    private void Start()
    {
        HaveBeenSold = haveBeenSold;
        priceText.text = price.ToString();
    }

    public int GetPrice()
    {
        return price;
    }

    public void ShowPrice(bool showPrice)
    {
        if(showPrice)
        {
            myPriceObject.SetActive(true);
            mySoldObject.SetActive(false);
        }
        else
        {
            myPriceObject.SetActive(false);
            mySoldObject.SetActive(true);
        }
    }
}
