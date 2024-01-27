using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackSystemBase
{
    private Player _player;
  
    public PlayerAttack Initialize(Player player)
    {
        _player = player;
        shootingPositions = _player.CurrentSkin.ShootingPoints;//todo
        GameManager.Instance.OnGameStarted += () => { isActive = true; };
        return this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    protected override Vector3 GetTargetDirection(Transform shootingPosition)
    {
        return shootingPosition.up;
    }
}
