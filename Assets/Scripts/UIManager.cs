using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;
    public delegate void UIDelegate();
    public static event UIDelegate EnterShop;
    public static event UIDelegate ExitShop;


    //References to UI
    public GameObject shopButton;
    public GameObject shopMenu;
    public GameObject hatSection;
    public GameObject clotheSection;
    public GameObject weaponSection;

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
        HideShopButton();
        ShowShopMenu();
        EnterShop?.Invoke();
    }

    public void CloseShop()
    {
        ShowShopButton();
        HideShopMenu();
        ExitShop?.Invoke();
    }

    public void ShowShopHatSection()
    {
        hatSection.SetActive(true);
        HideShopClotheSection();
        HideShopWeaponSection();
    }

    public void HideShopHatSection()
    {
        hatSection.SetActive(false);
    }

    public void ShowShopClotheSection()
    {
        clotheSection.SetActive(true);
        HideShopHatSection();
        HideShopWeaponSection();
    }

    public void HideShopClotheSection()
    {
        clotheSection.SetActive(false);
    }

    public void ShowShopWeaponSection()
    {
        weaponSection.SetActive(true);
        HideShopHatSection();
        HideShopClotheSection();
    }

    public void HideShopWeaponSection()
    {
        weaponSection.SetActive(false);
    }

}
