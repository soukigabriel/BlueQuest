using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public static Economy sharedInstance;

    [Header("Economy variables")]
    [Tooltip("Initial money that will have the player at the start of the game")]
    public int initialMoney;
    [Tooltip("Money that well be updated in real time and will be used for buying and selling")]
    int currentMoney;

    [Space]
    [Header("UI related to the economy")]
    public TMP_Text shopMoneyText;

    [Tooltip("This property allow us to manage the currentMoney and trigger events when it's value is modified")]
    public int CurrentMoney
    {
        get => currentMoney;
        set
        {
            currentMoney = value;
            shopMoneyText.text = currentMoney.ToString();
        }
    }

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

    private void Start()
    {
        CurrentMoney = initialMoney;
    }
}
