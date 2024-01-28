using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletBase
{
    protected override bool Check(HealthBase healthBase)
    {
        return healthBase.CharacterType != CharacterType.Enemy;
    }
}
