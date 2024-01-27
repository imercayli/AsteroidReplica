using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : HealthSystemBase
{
    public override CharacterType CharacterType => CharacterType.Enemy;

    protected override void Die()
    {
        
    }
}
