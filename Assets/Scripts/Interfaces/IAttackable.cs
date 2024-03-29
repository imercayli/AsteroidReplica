using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    float FireTime { get; set; }
    float FireRate { get; }
    int DamageAmount { get; }
    List<Transform> ShootingPositions { get; }
    ObjectPooling<BulletBase> BulletObjectPooling { get; }
    BulletBase BulletBase { get; }
    int BulletInitialSpawnAmount { get; }
    float BulletSpeed { get; }

    void Shoot();
}
