using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public Inventory inventory;
    public List<Transform> itemSlotContainers;
    public static UI_Inventory sharedInstance;


    private void Start()
    {
        if (sharedInstance == null) sharedInstance = this;
        else Destroy(gameObject);

        inventory = new Inventory();

        //inventory.AddItem(new Item { currentItemType = Item.ItemType.BasicHelmet, currentItemClass = Item.ItemClass.Hat });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.StrongArmor, currentItemClass = Item.ItemClass.Clothes });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.BasicArmor, currentItemClass = Item.ItemClass.Clothes });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.StrongArmor, currentItemClass = Item.ItemClass.Clothes });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.StrongHelmet, currentItemClass = Item.ItemClass.Hat });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.StrongSword, currentItemClass = Item.ItemClass.Weapon });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.BasicSword, currentItemClass = Item.ItemClass.Weapon });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.BasicSword, currentItemClass = Item.ItemClass.Weapon });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.StrongHelmet, currentItemClass = Item.ItemClass.Hat });
        //inventory.AddItem(new Item { currentItemType = Item.ItemType.BasicHelmet, currentItemClass = Item.ItemClass.Hat });
        //RefreshInventoryItem();
    }

    [ContextMenu("Refresh inventory")]
    public void RefreshInventoryItem()
    {
        foreach (Transform container in itemSlotContainers)
        {
            Transform itemSlotTemplate = container.Find("ItemSlotTemplate");

            foreach(Transform child in container)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }

            int x = 0, y = 0;
            float itemSlotCellSize = 30f, itemSlotPadding = 5f;

            foreach (Item item in inventory.GetItemList())
            {
                bool canBeInstantiated = false;
                switch (container.GetComponent<SlotContainer>().currentContainerType)
                {
                    case SlotContainerType.hat:

                        if(item.currentItemClass == Item.ItemClass.Hat)
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
                if (canBeInstantiated)
                {
                    RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, container).GetComponent<RectTransform>();
                    itemSlotRectTransform.gameObject.SetActive(true);
                    itemSlotRectTransform.anchoredPosition = new Vector2((x * itemSlotCellSize) + (x * itemSlotPadding), (y * itemSlotCellSize) + (y * itemSlotPadding));
                    Image itemImage = itemSlotRectTransform.Find("Item").GetComponent<Image>();
                    itemImage.sprite = item.GetSprite();
                    x++;
                    if(x>2)
                    {
                        x = 0;
                        y--;
                    }
                }
            }

        }
    }
}
