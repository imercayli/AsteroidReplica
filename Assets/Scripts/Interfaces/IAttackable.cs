using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    float FireTime { get; set; }
    float FireRate { get; }
    int DamagePower { get; }
    List<Transform> ShootingPositions { get; }
    BulletBase BulletBase { get; }
    int BulletInitialSpawnAmount { get; }
    float BulletSpeed { get; }

    void Shoot();
}
