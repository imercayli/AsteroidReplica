using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    [SerializeField] private float movementSpeed,rotationSpeed;
    
    public PlayerMovement Initialize(Player player)
    {
        _player = player;
        InputManager.Instance.OnTouchMoved += Move;
        return this;
    }
    private void Move(Vector2 touchDelta,float magnitude)
    {
         transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3)touchDelta.normalized,
             Time.deltaTime * movementSpeed * magnitude);

        if (magnitude > 0)
        {
            var angle = -Mathf.Atan2(touchDelta.x, touchDelta.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0,
             Mathf.LerpAngle(transform.localEulerAngles.z, angle, rotationSpeed * magnitude * Time.deltaTime));
        }
           
        
    }
}
