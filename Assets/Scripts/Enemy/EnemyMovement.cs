using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] private float angleRange;

    private Vector3 moveDirection;
    // Start is called before the first frame update
   
    public void Initialize()
    {
        Vector3  centerPosition = Vector3.zero;
        
        moveDirection = (centerPosition - transform.position).normalized;
       
        float angle = Random.Range(-angleRange, angleRange);
        moveDirection = Quaternion.Euler(0, 0, angle) * moveDirection;

        speed = GameManager.Instance.GameSettings.GetEnemySpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3.Lerp(transform.position, transform.position + moveDirection, Time.deltaTime * speed);

      
    }
}
