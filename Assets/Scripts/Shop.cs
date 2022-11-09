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

    private void OnEnable()
    {
        UIManager.EnterShop += OpenShop;
    }

    private void OnDisable()
    {
        UIManager.EnterShop -= OpenShop;
    }

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
