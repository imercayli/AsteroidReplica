using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.up, Time.deltaTime * 5);
    }
}
