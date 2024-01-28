using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public abstract class BulletBase : MonoBehaviour,IKillable
{
    private AttackBase _attackBase;
    public int DamageAmount => _attackBase.DamageAmount;
    
    public virtual void Initialize(AttackBase attackBase)
    {
        _attackBase = attackBase;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.up,
            Time.deltaTime * _attackBase.BulletSpeed);
    }
    
    public void GiveDamage(HealthBase healthBase)
    {
        if (!Check(healthBase)) return;
        
        healthBase.TakeDamage(DamageAmount);
        transform.SetParent(_attackBase.transform);
        _attackBase.BulletObjectPooling.AddObjectToPool(this);
    }
    
    protected abstract bool Check(HealthBase healthBase);
}
