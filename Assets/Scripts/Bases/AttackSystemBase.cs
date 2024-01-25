using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackSystemBase : MonoBehaviour,IAttackable
{
    public float FireTime { get; set; }
    
    [SerializeField] [Range(0f,1f)] private float fireRate;
    public float FireRate => fireRate;
    
    [SerializeField] private int damagePower;
    public int DamagePower => damagePower;
    
    [SerializeField] protected List<Transform> shootingPositions;
    public List<Transform> ShootingPositions => shootingPositions;
    
    [SerializeField] private BulletBase bulletBase;
    public BulletBase BulletBase => bulletBase;
    
    [SerializeField] private int bulletInitialSpawnAmount;
    public int BulletInitialSpawnAmount => bulletInitialSpawnAmount;
    
    [SerializeField] private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;

    protected void Start()
    {
        //spawn bullet
    }

    public virtual void Shoot()
    {
        if(Time.time < FireTime) return;
        
        FireTime = Time.time + FireRate;

        foreach (Transform shootingPosition in shootingPositions)
        {
            BulletBase bullet = Instantiate(BulletBase);
            bullet.transform.position = shootingPosition.transform.position;
            bullet.transform.rotation = shootingPosition.transform.rotation;
            bullet.Initialize(this);
        }

    }
}
