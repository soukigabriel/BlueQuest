using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    public List<Transform> itemSlotContainers;
    public UI_Inventory the_UI_Inventory;
    public Shop shop;

    private void Start()
    {
        SetShop();

        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Hat, currentItemType = Item.ItemType.BasicHelmet, haveBeenSold = true});
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Hat, currentItemType = Item.ItemType.StrongHelmet });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Clothes, currentItemType = Item.ItemType.BasicArmor, haveBeenSold = true });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Clothes, currentItemType = Item.ItemType.StrongArmor });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Weapon, currentItemType = Item.ItemType.BasicSword , haveBeenSold = true});
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Weapon, currentItemType = Item.ItemType.StrongSword });

        RefreshShop();
    }

    void SetShop()
    {
        shop = new Shop();
        shop.OnItemListChanged += Shop_OnItemListChanged;
    }

    private void Shop_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshShop();
    }

    void RefreshShop()
    {
        UI_Inventory.sharedInstance.inventory.ClearInventory();
        foreach (Transform container in itemSlotContainers)
        {
            Transform itemSlotTemplate = container.Find("ItemSlotTemplate");
            Transform hideItemButton = container.Find("hideItemButton");
            GameObject templateCostObject = itemSlotTemplate.Find("Cost").gameObject;
            templateCostObject.SetActive(false);

            foreach (Transform child in container)
            {
                if (child == itemSlotTemplate || child == hideItemButton) continue;
                Destroy(child.gameObject);
            }

            int x = 1, y = 0;
            float itemSlotCellSize = 30f, itemSlotPadding = 5f;

            foreach (Item item in shop.GetItemList())
            {
                bool canBeInstantiated = false;
                switch (container.GetComponent<SlotContainer>().currentContainerType)
                {
                    case SlotContainerType.hat:

                        if (item.currentItemClass == Item.ItemClass.Hat)
                        {
                            canBeInstantiated = true;
                        }
                        break;

                    case SlotContainerType.clothes:

                        if (item.currentItemClass == Item.ItemClass.Clothes)
                        {
                            canBeInstantiated = true;
                        }
                        break;

                    case SlotContainerType.weapon:
                        if (item.currentItemClass == Item.ItemClass.Weapon)
                        {
                            canBeInstantiated = true;
                        }
                        break;

                    default:
                        break;
                }
                if(canBeInstantiated)
                {
                    RectTransform shopItemRectTransform = Instantiate(itemSlotTemplate, container).GetComponent<RectTransform>();
                    shopItemRectTransform.anchoredPosition = new Vector2((x * itemSlotCellSize) + (x * itemSlotPadding), (y * itemSlotCellSize) + (y * itemSlotPadding));
                    shopItemRectTransform.gameObject.SetActive(true);
                    Image itemImage = shopItemRectTransform.Find("Item").GetComponent<Image>();
                    itemImage.sprite = item.GetSprite();
                    GameObject costObject = shopItemRectTransform.Find("Cost").gameObject;
                    TMP_Text costText = costObject.transform.Find("CostText").GetComponent<TMP_Text>();
                    costText.SetText(item.GetCost().ToString());
                    GameObject soldObject = shopItemRectTransform.Find("Sold").gameObject;
                    if (item.haveBeenSold)
                    {
                        UI_Inventory.sharedInstance.inventory.AddItem(item);
                        soldObject.SetActive(true);
                        costObject.SetActive(false);
                    }
                    else
                    {
                        soldObject.SetActive(false);
                        costObject.SetActive(true);
                    }

                    ShopItem shopItem = shopItemRectTransform.gameObject.AddComponent<ShopItem>();
                    shopItem.thisItem = item;

                    Button shopItemButton = shopItemRectTransform.GetComponent<Button>();
                    shopItemButton.onClick.RemoveAllListeners();
                    shopItemButton.onClick.AddListener(shopItem.SendCurrentItemToManager);
                    x++;
                    if (x > 2)
                    {
                        x = 0;
                        y--;
                    }
                }
            }
        }
    }
}
