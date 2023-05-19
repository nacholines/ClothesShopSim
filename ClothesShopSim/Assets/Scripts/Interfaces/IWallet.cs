using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWallet
{
    public float GetBalance();

    public void TakeMoney(float amount);

    
}
