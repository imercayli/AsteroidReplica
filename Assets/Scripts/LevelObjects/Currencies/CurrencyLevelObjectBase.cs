using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CurrencyLevelObjectBase : MonoBehaviour,IInteractable
{
    protected CurrencySpawner _currencySpawner;
    public abstract CurrencyType CurrencyType { get; }
    
   public void Initialize(CurrencySpawner currencySpawner)
   {
       _currencySpawner = currencySpawner;
        transform.DOScale(1, .5f).From(0);
    }
   
   public void Interact(Player player)
   {
       CurrencyManager.Instance.GetCurrencyData(CurrencyType).SetAmount();
       _currencySpawner.AddToPool(this);
   }
}
