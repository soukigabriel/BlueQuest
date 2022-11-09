using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;
    public delegate void UIDelegate();
    public static event UIDelegate EnterShop;
    public static event UIDelegate ExitShop;
    public static event UIDelegate EnterInventory;
    public static event UIDelegate ExitInventory;

    public string mainSceneName = "Main scene name here";
    public GameObject thePlayer;

    //References to UI
    public GameObject shopButton;
    public GameObject shopMenu;
    public GameObject shopHatSection;
    public GameObject shopClotheSection;
    public GameObject shopWeaponSection;
    public GameObject inventoryHatSection;
    public GameObject inventoryClotheSection;
    public GameObject inventoryWeaponSection;
    public GameObject mainMenu;
    public GameObject inventoryMenu;
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

    public void PlayButton()
    {
        thePlayer.SetActive(true);
        HideMainMenu();
        ShowHUD();
        SceneManager.LoadScene(mainSceneName);
    }

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

    public void OpenShop()
    {
        ShowShopMenu();
        HideHUD();
        EnterShop?.Invoke();
    }

    public void CloseShop()
    {
        HideShopMenu();
        ShowHUD();
        ExitShop?.Invoke();
    }

    public void OpenInventory()
    {
        HideHUD();
        ShowInventory();
        EnterInventory?.Invoke();
    }

    public void CloseInventory()
    {
        ShowHUD();
        HideInventory();
        ExitInventory?.Invoke();
    }

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
