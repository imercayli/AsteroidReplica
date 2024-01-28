using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyMovementBase EnemyMovementBase { get; private set; }
    public EnemyHealthBase EnemyHealthBase { get; private set; }
    public EnemyInteractionBase EnemyInteractionBase { get; private set; }
    
    public EnemySpawner EnemySpawner { get; private set; }
    public Action OnSpawned;

    public Action OnDied;
    private void Awake()
    {
        EnemyMovementBase = GetComponent<EnemyMovementBase>().Initialize(this);
        EnemyHealthBase = GetComponent<EnemyHealthBase>().Initialize(this);
        EnemyInteractionBase = GetComponent<EnemyInteractionBase>().Initialize(this);
    }

    public void EnemySpawned(EnemySpawner enemySpawner)
    {
        EnemySpawner = enemySpawner;
        OnSpawned?.Invoke();
    }

    public void Die()
    {
        GameManager.Instance.IncreaseScore();
        OnDied?.Invoke();
        SendToPool(true);

    }

   public abstract void SendToPool(bool isDied);
}
