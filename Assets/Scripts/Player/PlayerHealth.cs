using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Player _player;
    public int Health { get; protected set; }
    public int MaxHealth { get; protected set; }
    
    public PlayerHealth Initialize(Player player)
    {
        _player = player;
        return this;
    }
    
    public void TakeDamage(int damageAmount =1)
    {
        Health -= damageAmount;
        Death();
        
        if (Health <= 0)
        {
            FinishGame();
        }
    }
    
    private void Death()
    {
        
    }

    private void FinishGame()
    {
        
    }

}
