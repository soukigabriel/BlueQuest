using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Tooltip("Shared instance of the UI manager")]
    public static UIManager sharedInstance;

    [Tooltip("Main delegate of the UI")]
    public delegate void UIDelegate();
    [Tooltip("Event that will be triggered when the shop is opened")]
    public static event UIDelegate EnterShop;
    [Tooltip("Event that will be triggered when the shop is closed")]
    public static event UIDelegate ExitShop;
    [Tooltip("Event that will be triggered when the inventory is opened")]
    public static event UIDelegate EnterInventory;
    [Tooltip("Event that will be triggered when the inventory is closed")]
    public static event UIDelegate ExitInventory;

    [Tooltip("Name of the main scene")]
    public string mainSceneName = "Main scene name here";

    [Space]
    [Header("References to game objects")]
    [Tooltip("Reference to the player")]
    public GameObject thePlayer;
    [Tooltip("Reference to the shop button")]
    public GameObject shopButton;
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
    [Tooltip("Reference to the HUD")]
    public GameObject HUD;

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

        mainMenu.SetActive(true);
    }

    //This method is called by the Play button in the main menu and starts the game
    public void PlayButton()
    {

        //Change this to a event that will trigger when the game starts
        thePlayer.SetActive(true);


        HideMainMenu();
        ShowHUD();
        SceneManager.LoadScene(mainSceneName);
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
        ShowShopMenu();
        HideHUD();
        EnterShop?.Invoke();
    }

    //Close the shop and change the game state to inGame
    public void CloseShop()
    {
        HideShopMenu();
        ShowHUD();
        ExitShop?.Invoke();
    }

    //Open the Inventory and change the game state to inventory
    public void OpenInventory()
    {
        HideHUD();
        ShowInventory();
        EnterInventory?.Invoke();
    }

    //Close the Inventory and change the game state to inGame
    public void CloseInventory()
    {
        ShowHUD();
        HideInventory();
        ExitInventory?.Invoke();
    }

    //Change the current section of the shop menu to the hat section
    public void ShowShopHatSection()
    {
        shopHatSection.SetActive(true);
        HideShopClotheSection();
        HideShopWeaponSection();
    }

    public void HideShopHatSection()
    {
        shopHatSection.SetActive(false);
    }

    //Change the current section of the shop menu to the clothes section
    public void ShowShopClotheSection()
    {
        shopClotheSection.SetActive(true);
        HideShopHatSection();
        HideShopWeaponSection();
    }

    public void HideShopClotheSection()
    {
        shopClotheSection.SetActive(false);
    }

    //Change the current section of the shop menu to the weapon section
    public void ShowShopWeaponSection()
    {
        shopWeaponSection.SetActive(true);
        HideShopHatSection();
        HideShopClotheSection();
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

}
