using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class HealthBase : MonoBehaviour,IDamageable
{ 
    public int Health { get; set; }
    public int MaxHealth => maxHealth;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected Color damageParticleColor;
    
    public abstract CharacterType CharacterType { get; }
    protected virtual void Awake()
    {
        Health = MaxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
        
        SpawnParticle();
    }

    protected abstract void Die();

    private void SpawnParticle()
    {
        KillParticle killParticle =
            ObjectPoolingManager.Instance.KillParticleObjectPooling.GetObjectFromPool();
        killParticle.transform.position = transform.position;
        killParticle.Initialize(damageParticleColor);
    }
}
