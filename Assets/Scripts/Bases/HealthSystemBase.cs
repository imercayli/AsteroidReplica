using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystemBase : MonoBehaviour,IDamageable
{
    public int Health { get; set; }
    public int MaxHealth => maxHealth;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected GameObject hitParticle;//todo
    
    public abstract CharacterType CharacterType { get; }
    protected virtual void Awake()
    {
        Health = MaxHealth;
    }

    public virtual void ApplyDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
