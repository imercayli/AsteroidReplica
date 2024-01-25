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
        return this;
    }
}
