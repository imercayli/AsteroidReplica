using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoInteraction : EnemyInteractionBase
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.TryGetComponent(out BackgroundController backgroundController))
        {
            GetComponent<UfoAttack>().SetActivation(true);
        }
    }
}
