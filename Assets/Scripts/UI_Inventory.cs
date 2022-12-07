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

        SetInventory();
    }

    void SetInventory()
    {
        inventory = new Inventory();
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    [ContextMenu("Refresh inventory")]
    public void RefreshInventoryItems()
    {
        foreach (Transform container in itemSlotContainers)
        {
            Transform itemSlotTemplate = container.Find("ItemSlotTemplate");

            foreach(Transform child in container)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }

            int x = 1, y = 0;
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

                    /*
                     * 
                     * ToDo:
                     * 
                     * Hacer que al ser instanciados nuevos elementos en el inventario se le añada un listener para que dependiendo del tipo de Item el personaje cambie su ropa.
                     * 
                     */

                    InventoryItem inventoryItem = itemSlotRectTransform.gameObject.AddComponent<InventoryItem>();
                    inventoryItem.thisItem = item;

                    Button inventoryItemButton = itemSlotRectTransform.GetComponent<Button>();
                    inventoryItemButton.onClick.RemoveAllListeners();
                    inventoryItemButton.onClick.AddListener(inventoryItem.SetItem);


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
