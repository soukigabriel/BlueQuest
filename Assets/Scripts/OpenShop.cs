using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    //When enabled attach the OpenShop method to the EnterShop event
    private void OnEnable()
    {
        UIManager.EnterShop += OpenTheShop;
    }
    //When enabled detach the OpenShop method to the EnterShop event
    private void OnDisable()
    {
        UIManager.EnterShop -= OpenTheShop;
    }

    //The player will only be available to open the shop if he is in the shop zone through the shop button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.sharedInstance.ShowShopButton();
            UIManager.sharedInstance.SetDialogueButton(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.sharedInstance.HideShopButton();
            UIManager.sharedInstance.SetDialogueButton(false);
        }
    }

    public void OpenTheShop()
    {

    }
}
