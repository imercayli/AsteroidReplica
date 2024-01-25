using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystemBase
{
    private Player _player;
    public override CharacterType CharacterType => CharacterType.Player;
   
    public PlayerHealth Initialize(Player player)
    {
        _player = player;
        return this;
    }

    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
    }

    protected override void Die()
    {
        GameManager.Instance.FinishGame();
    }
}
