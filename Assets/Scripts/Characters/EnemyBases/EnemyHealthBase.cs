using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBase : HealthBase
{
    public override CharacterType CharacterType => CharacterType.Enemy;
    private EnemyBase _enemyBase;
    
    public EnemyHealthBase Initialize(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
        return this;
    }
    protected override void Die()
    {
        _enemyBase.Die();
    }
}
