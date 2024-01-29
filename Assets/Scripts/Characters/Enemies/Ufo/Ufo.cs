using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : EnemyBase
{
    public override void SendToPool(bool isDied)
    {
        EnemySpawner.OnUfoKilled(this,isDied);
    }
}
