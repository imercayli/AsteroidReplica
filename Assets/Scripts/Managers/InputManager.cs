using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoSingleton<InputManager>
{
    private InputActions InputActions { get; set; }
    private bool isActive, isTouchBegan;
    private Vector2 firstTouchPos, currentTouchPos;
    
    [SerializeField] private float radius;

    public Action<Vector2, float> OnTouchMoved;
    public Action OnTouchEnded;
    public float currentMagnitude;
    
     private void Start()
     { 
         InputActions = new InputActions();
         
         InputActions.Enable();
    
         InputActions.Player.TouchContact.started += OnStartTouch;
         InputActions.Player.TouchContact.canceled += OnEndTouch;
         InputActions.Player.TouchPosition.performed += OnTouchPositionChanged;
         isActive = true;
         GameManager.Instance.OnGameStarted += () => { isActive = true; };
     }
     
     private void OnStartTouch(InputAction.CallbackContext context)
     {
         if (!isActive)
             return;

         isTouchBegan = true;
         firstTouchPos = InputActions.Player.TouchPosition.ReadValue<Vector2>();
     }
     
    private void OnTouchPositionChanged(InputAction.CallbackContext context)
    {
        if (!isActive) return;
        
        if (!isTouchBegan)
        {
            isTouchBegan = true;
            firstTouchPos = InputActions.Player.TouchPosition.ReadValue<Vector2>();
        }

        currentTouchPos = InputActions.Player.TouchPosition.ReadValue<Vector2>();

        Vector2 offset = firstTouchPos - currentTouchPos;
        firstTouchPos = currentTouchPos + Vector2.ClampMagnitude(offset, radius);

        Vector2 direction = currentTouchPos - firstTouchPos;

        float magnitude = Mathf.InverseLerp(0.1f, radius, direction.magnitude);
        currentMagnitude = magnitude;

        OnTouchMoved?.Invoke(direction.normalized, magnitude);
    }
   
   
   
    private void OnEndTouch(InputAction.CallbackContext context)
    {
        isTouchBegan = false;
        currentMagnitude = 1;
        OnTouchEnded?.Invoke();
    }
    
    private void OnDestroy()
    {
        InputActions.Player.TouchContact.started -= OnStartTouch;
        InputActions.Player.TouchContact.canceled -= OnEndTouch;
        InputActions.Player.TouchPosition.performed -= OnTouchPositionChanged;
         
        InputActions.Disable();
    }
}
