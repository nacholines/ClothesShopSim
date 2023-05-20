using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : IWallet
{
    private float _balance;

    public void SetBalance(float amount)
    {
        _balance = amount;
    }
    public float GetBalance()
    {
        return _balance;
    }

    public void TakeMoney(float amount)
    {
        _balance -= amount;
    }

    public void AddMoney(float amount)
    {
        _balance += amount;
    }
}
