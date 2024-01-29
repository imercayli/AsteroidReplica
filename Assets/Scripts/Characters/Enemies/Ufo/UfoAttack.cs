using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoAttack : AttackBase
{
    private void Update()
    {
        Shoot();
    }
    
    protected override Vector3 GetTargetDirection(Transform shootingPosition)
    {
        return Player.Instance.transform.position - shootingPosition.position;
    }

}
