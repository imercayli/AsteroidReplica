using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour,IInteractable
{
    public void Interact(Player player)
    {
        CurrencyManager.Instance.GetCurrencyData(CurrencyType.Coin).SetAmount();
    }
}
