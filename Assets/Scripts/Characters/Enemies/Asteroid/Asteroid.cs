using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBase
{
    [SerializeField] private int level;
    public int Level => level;
    public override void SendToPool(bool isDied)
    {
        EnemySpawner.OnAstreoidKilled(this,isDied);
    }
}
