using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    private Player _player;
    public override CharacterType CharacterType => CharacterType.Player;
    public Action<int> OnPlayerHealthChanged;
    [SerializeField] protected bool isImmortal;
    protected bool IsImmortal
    {
        get
        {
            #if !UNITY_EDITOR
            return false;
            #endif

            return isImmortal;
        }
    }

    protected bool isReborning;
   
    public PlayerHealth Initialize(Player player)
    {
        _player = player;
        _player.OnReborn += OnReborn;
        return this;
    }

    public override void TakeDamage(int damage)
    {
        if(IsImmortal || isReborning) return;
        base.TakeDamage(damage);
        OnPlayerHealthChanged?.Invoke(Health);
        
        if (Health > 0)
            _player.Reborn();
    }

    protected override void Die()
    {
       _player.Die();
    }

    private void OnReborn(float rebornTime)
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            isReborning = true;
            yield return new WaitForSeconds(rebornTime);
            isReborning = false;
        }
    }
}
