using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2Event movementEvent;
    public BoolEvent actionEvent;

    private Vector2 initialTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isTouching;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (isTouching)
        {
            movementEvent.Raise(Vector2.ClampMagnitude(currentTouchPosition - initialTouchPosition, Screen.width*0.4f)*Time.deltaTime * 5);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            movementEvent.Raise(context.ReadValue<Vector2>());
        }
        if (context.performed)
        {
            movementEvent.Raise(context.ReadValue<Vector2>());
        }
        if (context.canceled)
        {
            movementEvent.Raise(Vector2.zero);
        }

    }

    public void OnAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            actionEvent.Raise(true);
            isTouching = true;
            initialTouchPosition = currentTouchPosition;
        }
        if (context.canceled)
        {
            actionEvent.Raise(false);
            isTouching = false;
        }
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            
            currentTouchPosition = initialTouchPosition;
        }
        if (context.performed)
        {
            currentTouchPosition = context.ReadValue<Vector2>();
        }
        if (context.canceled)
        {

        }
    }
}
