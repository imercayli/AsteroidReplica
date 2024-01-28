using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackBase
{
    private Player _player;
  
    public PlayerAttack Initialize(Player player)
    {
        _player = player;
        SetShootingPositions();
        _player.OnSkinChange += SetShootingPositions;
        GameManager.Instance.OnGameStarted += () => { _isActive = true; };
        return this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    private void SetShootingPositions()
    {
        shootingPositions = _player.CurrentSkin.ShootingPoints;
    }

    protected override Vector3 GetTargetDirection(Transform shootingPosition)
    {
        return shootingPosition.up;
    }
}
