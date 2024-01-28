using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    int DamageAmount { get; }
    void GiveDamage(HealthBase healthBase);
}
