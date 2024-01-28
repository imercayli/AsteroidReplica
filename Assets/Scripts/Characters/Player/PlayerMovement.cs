using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private bool isActive;
    [SerializeField] private float movementSpeed,rotationSpeed;
    
    public PlayerMovement Initialize(Player player)
    {
        _player = player;
        InputManager.Instance.OnTouchMoved += Move;
        GameManager.Instance.OnGameStarted += () => { isActive = true; };
        return this;
    }
    private void Move(Vector2 touchDelta,float magnitude)
    {
        if(!isActive) return;
        
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
