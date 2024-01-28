using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractionBase : InteractionBase
{
    private EnemyBase _enemyBase;
    public EnemyInteractionBase Initialize(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
        return this;
    }
    
    protected override void ExitFromScreen()
    {
       _enemyBase.SendToPool(false);
    }
}
