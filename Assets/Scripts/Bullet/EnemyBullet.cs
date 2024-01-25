using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletBase
{
    protected override bool Check(GameObject gameObject)
    {
        return gameObject.GetComponent<HealthSystemBase>().CharacterType != CharacterType.Enemy;
    }
}
