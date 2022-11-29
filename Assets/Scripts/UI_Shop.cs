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
        shop = new Shop();

        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Hat, currentItemType = Item.ItemType.BasicHelmet });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Hat, currentItemType = Item.ItemType.StrongHelmet });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Clothes, currentItemType = Item.ItemType.BasicArmor });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Clothes, currentItemType = Item.ItemType.StrongArmor });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Weapon, currentItemType = Item.ItemType.BasicSword });
        shop.AddItem(new Item { currentItemClass = Item.ItemClass.Weapon, currentItemType = Item.ItemType.StrongSword });

        RefreshShop();
    }

    void RefreshShop()
    {
        foreach (Transform container in itemSlotContainers)
        {
            Transform itemSlotTemplate = container.Find("ItemSlotTemplate");
            GameObject templateCostObject = itemSlotTemplate.Find("Cost").gameObject;
            templateCostObject.SetActive(false);

            foreach (Transform child in container)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.transform);
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
                    Image itemImage = shopItemRectTransform.Find("Item").GetComponent<Image>();
                    itemImage.sprite = item.GetSprite();
                    GameObject costObject = shopItemRectTransform.Find("Cost").gameObject;
                    costObject.SetActive(true);
                    TMP_Text costText = costObject.transform.Find("CostText").GetComponent<TMP_Text>();
                    costText.SetText(item.GetCost().ToString());
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
