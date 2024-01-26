using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondObject : MonoBehaviour,IInteractable
{
    public void Interact(Player player)
    {
        CurrencyManager.Instance.GetCurrencyData(CurrencyType.Diamond).SetAmount();
    }
}
