using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CurrencyLevelObjectBase : LevelObjectBase,IPlayerInteractable
{
    public abstract CurrencyType CurrencyType { get; }
    private CurrencySpawner _currencySpawner;
    [SerializeField] protected Color particleColor;
    
   // public override void Initialize(SpawnerBase spawnerBase)
   // {
   //     base.Initialize(spawnerBase);
   //     transform.DOScale(1, .5f).From(0);
   // }

   public void Initialize(CurrencySpawner currencySpawner)
   {
       _currencySpawner = currencySpawner;
       transform.DOScale(1, .5f).From(0);
   }

   public void Interact(Player player)
   {
       CurrencyManager.Instance.GetCurrencyData(CurrencyType).SetAmount();
       LevelObjectInteractParticle levelObjectInteractParticle =
           ObjectPoolingManager.Instance.LevelObjectInteractParticleObjectPooling.GetObjectFromPool();
       levelObjectInteractParticle.transform.position = transform.position;
       levelObjectInteractParticle.Initialize(particleColor);
       _currencySpawner.AddToPool(this);
   }
   
   
}
