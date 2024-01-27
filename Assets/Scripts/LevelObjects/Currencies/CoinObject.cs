using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : CurrencyLevelObjectBase,IInteractable
{
    public override CurrencyType CurrencyType => CurrencyType.Coin;
   
}
