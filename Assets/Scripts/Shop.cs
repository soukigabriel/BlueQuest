using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //public static string hatOne = "Hat One";
    //public static string hatTwo = "Hat Two";
    //public static string clotheOne = "Clothe One";
    //public static string clotheTwo = "Clothe Two";
    //public static string swordOne = "Sword One";
    //public static string swordTwo = "Sword Two";

    //[Tooltip("Stores the list of items in the shop and if they have been purchased")]
    //public static Dictionary<string, bool> shopItems = new Dictionary<string, bool>();


    public static Shop sharedInstance;

    private void Awake()
    {
        //if(sharedInstance == null)
        //{
        //    sharedInstance = this;
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}

        //shopItems.Add(hatOne, false);
        //shopItems.Add(hatTwo, false);
        //shopItems.Add(clotheOne, true);
        //shopItems.Add(clotheTwo, false);
        //shopItems.Add(swordOne, true);
        //shopItems.Add(swordTwo, false);
    }

    
}
