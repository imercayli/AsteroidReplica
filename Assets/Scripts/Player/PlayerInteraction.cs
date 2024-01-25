using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteraction : MonoBehaviour
{
    private Player _player;
    
    public PlayerInteraction Initialize(Player player)
    {
        _player = player;
        return this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(_player);
        }
    }
}
