using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    bool haveBeenPurchased = false;

    public enum ItemClass
    {
        Hat,
        Clothes,
        Weapon
    }
    public enum ItemType
    {
        BasicHelmet,
        StrongHelmet,
        BasicArmor,
        StrongArmor,
        BasicSword,
        StrongSword
    }

    public ItemClass currentItemClass;
    public ItemType currentItemType;

    public Sprite GetSprite()
    {
        switch (currentItemType)
        {
            default:
            case ItemType.BasicHelmet:  return ItemAssets.sharedInstance.basicHelmetSprite;
            case ItemType.StrongHelmet: return ItemAssets.sharedInstance.strongHelmetSprite;
            case ItemType.BasicArmor:   return ItemAssets.sharedInstance.basicArmorSprite;
            case ItemType.StrongArmor:  return ItemAssets.sharedInstance.strongArmorSprite;
            case ItemType.BasicSword:   return ItemAssets.sharedInstance.basicSwordSprite;
            case ItemType.StrongSword:  return ItemAssets.sharedInstance.strongSwordSprite;
        }
    }

    public int GetCost()
    {
        switch (currentItemType)
        {
            default:
            case ItemType.BasicHelmet:  return 200;
            case ItemType.StrongHelmet: return 500;
            case ItemType.BasicArmor:   return 600;
            case ItemType.StrongArmor:  return 1000;
            case ItemType.BasicSword:   return 600;
            case ItemType.StrongSword:  return 1500;
        }
    }
}
