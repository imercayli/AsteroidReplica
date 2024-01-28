using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInteraction : InteractionBase
{
    private Player _player;
    
    public PlayerInteraction Initialize(Player player)
    {
        _player = player;
        return this;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        
        if (other.TryGetComponent(out IPlayerInteractable interactable))
        {
            interactable.Interact(_player);
        }
    }

    protected override void ExitFromScreen()
    {
        
    }
}
