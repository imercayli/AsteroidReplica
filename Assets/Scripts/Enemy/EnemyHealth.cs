using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystemBase
{
    public override CharacterType CharacterType => CharacterType.Enemy;
    protected override void Die()
    {
      GameManager.Instance.IncreaseScore();
      gameObject.SetActive(false);//back to pool todo
    }
}
