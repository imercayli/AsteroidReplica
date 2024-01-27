using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondObject : CurrencyLevelObjectBase,IInteractable
{
    public override CurrencyType CurrencyType => CurrencyType.Diamond;
    
}
