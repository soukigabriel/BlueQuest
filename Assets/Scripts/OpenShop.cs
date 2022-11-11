using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
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
}
