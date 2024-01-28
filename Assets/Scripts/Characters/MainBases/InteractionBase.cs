using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(HealthBase))]
 public abstract class InteractionBase : MonoBehaviour
 {
     protected virtual void OnTriggerEnter2D(Collider2D other)
     {
         if (other.TryGetComponent(out IKillable iKillable))
         {
             iKillable.GiveDamage(GetComponent<HealthBase>());
         }
     }

     protected virtual void OnTriggerExit2D(Collider2D other)
     {
         if (other.TryGetComponent(out BackgroundController backgroundController))
         {
            ExitFromScreen();
         }
     }
     
     protected abstract void ExitFromScreen();
 }
