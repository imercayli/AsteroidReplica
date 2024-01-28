using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class ObstacleBase : MonoBehaviour,IKillable
{
    [SerializeField] private int damageAmount = 1;
    public int DamageAmount => damageAmount;

    public void GiveDamage(HealthBase healthBase)
    {
       healthBase.TakeDamage(DamageAmount);
    }
}
