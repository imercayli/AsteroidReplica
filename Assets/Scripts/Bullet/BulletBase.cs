using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    private AttackSystemBase _attackSystemBase;
    
    public virtual void Initialize(AttackSystemBase attackSystemBase)
    {
        _attackSystemBase = attackSystemBase;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.up,
            Time.deltaTime * _attackSystemBase.BulletSpeed);
    }
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if (Check(other.gameObject))
            {
                damageable.ApplyDamage(_attackSystemBase.DamagePower);
                //send back to pool todo
            }
        }
      
    }

    protected abstract bool Check(GameObject gameObject);
}
