using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed,angleRange;

    private Vector3 moveVector,moveDirection;
    // Start is called before the first frame update
    void Start()
    {
         
        Vector3  centerPosition = Vector3.zero;
        moveDirection = (centerPosition - transform.position).normalized;

        float angle = Random.Range(-angleRange, angleRange);
        moveDirection = Quaternion.Euler(0, 0, angle) * moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position =
        //     Vector3.Lerp(transform.position, transform.position + moveVector, Time.deltaTime * speed);
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
