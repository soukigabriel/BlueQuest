using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Tooltip("Shared instance of the UI manager")]
    public static UIManager sharedInstance;

    [Tooltip("Name of the main scene")]
    public string mainSceneName = "Main scene name here";
    [Tooltip("Name of the main menu scene")]
    public string mainMenuName = "Main menu name here";

    [Space]
    [Header("References to game objects")]
    [Tooltip("Reference to the player")]
    public GameObject thePlayer;
    [Tooltip("Reference to the shop button")]
    public GameObject shopButton;
    [Tooltip("Reference to the dialogue button")]
    public GameObject dialogueButton;
    [Tooltip("Reference to the shop menu")]
    public GameObject shopMenu;
    [Tooltip("Reference to the shop hat section")]
    public GameObject shopHatSection;
    [Tooltip("Reference to the shop clothe section")]
    public GameObject shopClotheSection;
    [Tooltip("Reference to the shop weapon section")]
    public GameObject shopWeaponSection;
    [Tooltip("Reference to the shop inventory hat section")]
    public GameObject inventoryHatSection;
    [Tooltip("Reference to the shop inventory clothes section")]
    public GameObject inventoryClotheSection;
    [Tooltip("Reference to the shop inventory weapon section")]
    public GameObject inventoryWeaponSection;
    [Tooltip("Reference to the main menu")]
    public GameObject mainMenu;
    [Tooltip("Reference to the inventory menu")]
    public GameObject inventoryMenu;
    [Tooltip("Reference to the pause menu")]
    public GameObject pauseMenu;
    [Tooltip("Reference to the HUD")]
    public GameObject HUD;
    [Tooltip("Reference to the UI character camera")]
    public GameObject UICharacterCamera;
    [Tooltip("Reference to the sell button")]
    public GameObject sellButton;
    [Tooltip("Reference to the buy button")]
    public GameObject buyButton;
    [Tooltip("Reference to the dialogue box")]
    public GameObject dialogBox;
    const string mainSceneSpawnName = "MainScene";

    [SerializeField] Item currentSelectedItem;
    [SerializeField] GameObject currentSelectedObject;

    [SerializeField] ClothesChange m_ClothesChange;

    [SerializeField] List<ShopItem> hatItems = new List<ShopItem>();
    [SerializeField] List<ShopItem> clothesItems = new List<ShopItem>();
    [SerializeField] List<ShopItem> weaponItems = new List<ShopItem>();

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //mainMenu.SetActive(true);
    }

    //This method is called by the Play button in the main menu and starts the game
    public void PlayButton()
    {
        Fade.sharedInstance.InitialFadeIn();
    }

    public void StartGame()
    {
        thePlayer.SetActive(true);
        thePlayer.GetComponent<PlayerController>().nextSpawnPoint = mainSceneSpawnName;
        HideMainMenu();
        ShowHUD();
        if(GameManager.sharedInstance.initialCinematicTriggered)
        {
            GameManager.sharedInstance.SetGameState(GameState.inGame);
        }
        SceneManager.LoadScene(mainSceneName);
    }

    public void MainMenuButton()
    {
        thePlayer.SetActive(false);

        dialogBox.SetActive(false);
        ShowMainMenu();
        SetPauseMenu(false);
        HideHUD();
        GameManager.sharedInstance.SetGameState(GameState.mainMenu);
        SceneManager.LoadScene(mainMenuName);
    }


    //This method is called by the Exit button in the main menu and exits the game
    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void ShowUICharacterCamera()
    {
        UICharacterCamera.SetActive(true);
    }

    void HideUICharacterCamera()
    {
        UICharacterCamera.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }

    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void ShowHUD()
    {
        HUD.SetActive(true);
    }

    public void HideHUD()
    {
        HUD.SetActive(false);
    }

    public void ShowShopButton()
    {
        shopButton.SetActive(true);
    }

    public void HideShopButton()
    {
        shopButton.SetActive(false);
    }

    void ShowShopMenu()
    {
        shopMenu.SetActive(true);
    }

    void HideShopMenu()
    {
        shopMenu.SetActive(false);
    }

    //Open the shop and change the game state to shoping
    public void OpenShop()
    {
        ShowUICharacterCamera();
        ShowShopMenu();
        HideHUD();
        ShowShopHatSection();
        SetBuyButton(false);
        SetSellButton(false);
        GameManager.sharedInstance.SetGameState(GameState.shoping);
        currentSelectedObject = null;
    }

    //Close the shop and change the game state to inGame
    public void CloseShop()
    {
        HideUICharacterCamera();
        HideShopMenu();
        ShowHUD();
        GameManager.sharedInstance.SetGameState(GameState.inGame);
    }

    //Open the Inventory and change the game state to inventory
    public void OpenInventory()
    {
        ShowUICharacterCamera();
        HideHUD();
        ShowInventory();
        ShowInventoryHatSection();
        GameManager.sharedInstance.SetGameState(GameState.inInventory);
    }

    //Close the Inventory and change the game state to inGame
    public void CloseInventory()
    {
        HideUICharacterCamera();
        ShowHUD();
        HideInventory();
        GameManager.sharedInstance.SetGameState(GameState.inGame);
    }

    //bool ItemHaveBeenSold(ShopItem item)
    //{
    //    if (item.HaveBeenSold)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //void SetPriceObject(List<ShopItem> itemList)
    //{
    //    foreach (ShopItem item in itemList)
    //    {
    //        if (ItemHaveBeenSold(item))
    //        {
    //            item.myPriceObject.SetActive(false);
    //            item.mySoldObject.SetActive(true);
    //        }
    //        else
    //        {
    //            item.myPriceObject.SetActive(true);
    //            item.mySoldObject.SetActive(false);
    //        }
    //    }
    //}

    //Change the current section of the shop menu to the hat section
    public void ShowShopHatSection()
    {
        SetBuyButton(false);
        SetSellButton(false);
        currentSelectedObject = null;
        shopHatSection.SetActive(true);
        HideShopClotheSection();
        HideShopWeaponSection();
        //SetPriceObject(hatItems);
    }

    public void HideShopHatSection()
    {
        shopHatSection.SetActive(false);
    }

    //Change the current section of the shop menu to the clothes section
    public void ShowShopClotheSection()
    {
        SetBuyButton(false);
        SetSellButton(false);
        currentSelectedObject = null;
        shopClotheSection.SetActive(true);
        HideShopHatSection();
        HideShopWeaponSection();
        //SetPriceObject(clothesItems);
    }

    public void HideShopClotheSection()
    {
        shopClotheSection.SetActive(false);
    }

    //Change the current section of the shop menu to the weapon section
    public void ShowShopWeaponSection()
    {
        SetBuyButton(false);
        SetSellButton(false);
        currentSelectedObject = null;
        shopWeaponSection.SetActive(true);
        HideShopHatSection();
        HideShopClotheSection();
        //SetPriceObject(weaponItems);
    }

    public void HideShopWeaponSection()
    {
        shopWeaponSection.SetActive(false);
    }

    public void ShowInventory()
    {
        inventoryMenu.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryMenu.SetActive(false);
    }

    //Change the current section of the inventory menu to the hat section
    public void ShowInventoryHatSection()
    {
        inventoryHatSection.SetActive(true);
        HideInventoryClotheSection();
        HideInventoryWeaponSection();
    }

    public void HideInventoryHatSection()
    {
        inventoryHatSection.SetActive(false);
    }

    //Change the current section of the inventory menu to the clothes section
    public void ShowInventoryClotheSection()
    {
        inventoryClotheSection.SetActive(true);
        HideInventoryHatSection();
        HideInventoryWeaponSection();
    }

    public void HideInventoryClotheSection()
    {
        inventoryClotheSection.SetActive(false);
    }

    //Change the current section of the inventory menu to the weapon section
    public void ShowInventoryWeaponSection()
    {
        inventoryWeaponSection.SetActive(true);
        HideInventoryHatSection();
        HideInventoryClotheSection();
    }

    public void HideInventoryWeaponSection()
    {
        inventoryWeaponSection.SetActive(false);
    }

    void SetBuyButton(bool newValue)
    {
        buyButton.SetActive(newValue);
    }

    void SetSellButton(bool newValue)
    {
        sellButton.SetActive(newValue);
    }

    public void SetCurrentSelectedObject(Item selectedItem, GameObject selectedObject)
    {
        currentSelectedObject = selectedObject;
        currentSelectedItem = selectedItem;
        if (!currentSelectedItem.haveBeenSold)
        {
            SetBuyButton(true);
            SetSellButton(false);
        }
        else
        {
            m_ClothesChange.EquipItem(currentSelectedItem);
            SetBuyButton(false);
            SetSellButton(true);
        }
    }

    public void BuyItem()
    {
        if (currentSelectedItem.GetCost() <= Economy.sharedInstance.CurrentMoney && !currentSelectedItem.haveBeenSold)
        {
            Economy.sharedInstance.CurrentMoney -= currentSelectedItem.GetCost();
            currentSelectedItem.haveBeenSold = true;
            SetBuyButton(false);
            SetSellButton(true);
            currentSelectedObject.transform.Find("Cost").gameObject.SetActive(false);
            currentSelectedObject.transform.Find("Sold").gameObject.SetActive(true);
            m_ClothesChange.EquipItem(currentSelectedItem);
            UI_Inventory.sharedInstance.inventory.AddItem(currentSelectedItem);
            UI_Inventory.sharedInstance.RefreshInventoryItems();
        }
    }

    public void SellItem()
    {
        if(currentSelectedItem.haveBeenSold)
        {
            Economy.sharedInstance.CurrentMoney += currentSelectedItem.GetCost();
            currentSelectedItem.haveBeenSold = false;
            SetBuyButton(true);
            SetSellButton(false);
            currentSelectedObject.transform.Find("Sold").gameObject.SetActive(false);
            currentSelectedObject.transform.Find("Cost").gameObject.SetActive(true);
            m_ClothesChange.UnequipItem(currentSelectedItem);
            UI_Inventory.sharedInstance.inventory.RemoveItem(currentSelectedItem);
            UI_Inventory.sharedInstance.RefreshInventoryItems();
        }
    }

    public void SetDialogueButton(bool setValue)
    {
        dialogueButton.SetActive(setValue);
    }

    public void ResumeButton()
    {
        //Vuelve al estado ingame
        SetPauseMenu(false);
    }

    public void PauseButton()
    {
        SetPauseMenu(true);
    }

    void SetPauseMenu(bool value)
    {
        if(value)
        {
            GameManager.sharedInstance.SetGameState(GameState.inPause);
        }
        else
        {
            GameManager.sharedInstance.SetGameState(GameState.inGame);
        }
        pauseMenu.SetActive(value);
    }

}
