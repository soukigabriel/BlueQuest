using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public int initialMoney;
    int money;

    public TMP_Text shopMoneyText;

    public int Money
    {
        get => money;
        set
        {
            money = value;
            shopMoneyText.text = money.ToString();
        }
    }

    private void Start()
    {
        Money = initialMoney;
    }

    public void ManageMoney(int value)
    {
        money += value;
    }
}
