using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovementBase : MonoBehaviour
{
    protected EnemyBase _enemyBase;
    protected float speed;
    [SerializeField] protected float angleRange;
    protected Vector3 moveDirection;

    public EnemyMovementBase Initialize(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
        enemyBase.OnSpawned += SetMoveDirection;
        return this;
    }
    
    protected virtual void SetMoveDirection()
    {
        Vector3  centerPosition =Vector3.zero;
        moveDirection = (centerPosition - transform.position).normalized;
         
        float angle = Random.Range(-angleRange, angleRange);
        moveDirection = Quaternion.Euler(0, 0, angle) * moveDirection;

        speed = GameManager.Instance.GameSettings.GetEnemySpeed();
    }

    
    protected virtual void Update()
    {
       Move();
    }
    protected virtual void Move()
    {
        transform.position =
            Vector3.Lerp(transform.position, transform.position + moveDirection, Time.deltaTime * speed);
    }
}
