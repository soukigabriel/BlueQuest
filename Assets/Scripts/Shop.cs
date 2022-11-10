using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop sharedInstance;

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

    //When enabled attach the OpenShop method to the EnterShop event
    private void OnEnable()
    {
        UIManager.EnterShop += OpenShop;
    }
    //When enabled detach the OpenShop method to the EnterShop event
    private void OnDisable()
    {
        UIManager.EnterShop -= OpenShop;
    }

    //The player will only be available to open the shop if he is in the shop zone through the shop button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            UIManager.sharedInstance.ShowShopButton();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            UIManager.sharedInstance.HideShopButton();
        }
    }

    public void OpenShop()
    {
        
    }
}
