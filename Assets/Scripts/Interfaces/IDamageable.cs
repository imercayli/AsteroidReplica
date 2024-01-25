using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int Health { get; set; }
    int MaxHealth { get; }

    void ApplyDamage(int damage);
}