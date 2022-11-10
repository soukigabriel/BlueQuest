using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory sharedInstance;
    [SerializeField] List<GameObject> inventoryHats = new List<GameObject>();
    [SerializeField] List<GameObject> inventoryClothes = new List<GameObject>();
    [SerializeField] List<GameObject> inventoryWeapons = new List<GameObject>();
    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddItem(ShopItem item)
    {
        switch (item.currentItemType)
        {
            case ItemType.HatOne:
                inventoryHats.Add(item.gameObject);
                break;
            case ItemType.HatTwo:
                inventoryHats.Add(item.gameObject);
                break;
            case ItemType.ClothesOne:
                inventoryClothes.Add(item.gameObject);            
                break;
            case ItemType.ClothesTwo:
                inventoryClothes.Add(item.gameObject);
                break;
            case ItemType.SwordOne:
                inventoryWeapons.Add(item.gameObject);
                break;
            case ItemType.SwordTwo:
                inventoryWeapons.Add(item.gameObject);
                break;

            default:
                break;
        }
    }

    public void RemoveItem(ShopItem item)
    {
        switch (item.currentItemType)
        {
            case ItemType.HatOne:
                inventoryHats.Remove(item.gameObject);
                break;
            case ItemType.HatTwo:
                inventoryHats.Remove(item.gameObject);
                break;
            case ItemType.ClothesOne:
                inventoryClothes.Remove(item.gameObject);
                break;
            case ItemType.ClothesTwo:
                inventoryClothes.Remove(item.gameObject);
                break;
            case ItemType.SwordOne:
                inventoryWeapons.Remove(item.gameObject);
                break;
            case ItemType.SwordTwo:
                inventoryWeapons.Remove(item.gameObject);
                break;

            default:
                break;
        }
    }
}
