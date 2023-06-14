using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private float moneyAmount = 0;
    private const string MoneyPrefix = "MONEY: ";

    public void UpdateMoneyAmount(float newAmount)
    {
        moneyAmount = newAmount;
        moneyText.text = MoneyPrefix + moneyAmount.ToString();
    }
}
