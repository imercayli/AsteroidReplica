using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackSystemBase : MonoBehaviour,IAttackable
{
    public float FireTime { get; set; }
    
    [SerializeField] [Range(0f,10f)] private float fireRate;
    public float FireRate => fireRate;
    
    [SerializeField] private int damagePower;
    public int DamagePower => damagePower;
    
    [SerializeField] protected List<Transform> shootingPositions;
    public List<Transform> ShootingPositions => shootingPositions;
    
    private ObjectPooling<BulletBase> _bulletObjectPooling;
    public ObjectPooling<BulletBase> BulletObjectPooling => _bulletObjectPooling;
    
    [SerializeField] private BulletBase bulletBase;
    public BulletBase BulletBase => bulletBase;
    
    [SerializeField] private int bulletInitialSpawnAmount;
    public int BulletInitialSpawnAmount => bulletInitialSpawnAmount;
    
    [SerializeField] private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;
    
    protected bool isActive;
    
    protected virtual void Start()
    {
        _bulletObjectPooling = new ObjectPooling<BulletBase>(BulletBase, transform, BulletInitialSpawnAmount);
        GameManager.Instance.OnGameOver += () => isActive = false;
    }
    
    public virtual void Shoot()
    {
        if(!isActive) return;
        
        if(Time.time < FireTime) return;
        
        FireTime = Time.time + FireRate;

        foreach (Transform shootingPosition in shootingPositions)
        {
            BulletBase bullet = _bulletObjectPooling.GetObjectFromPool();
            bullet.transform.SetParent(null);
            bullet.transform.position = shootingPosition.transform.position;
            bullet.transform.up = GetTargetDirection(shootingPosition);
            bullet.Initialize(this);
        }

    }

    protected abstract Vector3 GetTargetDirection(Transform shootingPosition);
}
