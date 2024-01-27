using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackSystemBase
{
    protected override void Start()
    {
        base.Start();
        isActive = true;
    }
    private void Update()
    {
        Shoot();
    }
    
    protected override Vector3 GetTargetDirection(Transform shootingPosition)
    {
        return Player.Instance.transform.position - shootingPosition.position;
    }

}
