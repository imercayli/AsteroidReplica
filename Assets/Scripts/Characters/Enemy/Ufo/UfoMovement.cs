using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UfoMovement : EnemyMovementBase
{
    private int _changeDirectionCount;
    private float _changeDirectionTimer;

    protected override void Update()
    {
        base.Update();
        
        ChangeMoveDirection();
    }

    private void ChangeMoveDirection()
    {
        if (Time.time > _changeDirectionTimer && _changeDirectionCount > 0)
        {
            float angle = Random.Range(-angleRange, angleRange);
            moveDirection = Quaternion.Euler(0, 0, angle) * moveDirection;
            _changeDirectionCount--;
            _changeDirectionTimer = Time.time + Random.Range(2f, 3f);
            
        }
    }
}
