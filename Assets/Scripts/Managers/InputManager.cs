using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2Event movementEvent;
    public BoolEvent actionEvent;

    public Vector2Event joystickInitialEvent;
    public Vector2Event joystickCurrentEvent;

    private Vector2 initialTouchPosition;
    private Vector2 currentTouchPosition;

    private Vector2 hwh;
    public float joystickSize = 0.13f;

    private bool isTouching;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        hwh = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }

    private void Update()
    {
        if (isTouching)
        {
            movementEvent.Raise(Vector2.ClampMagnitude(currentTouchPosition - initialTouchPosition, Screen.width*joystickSize)*Time.deltaTime * 7);
            joystickCurrentEvent.Raise(Vector2.ClampMagnitude(currentTouchPosition - initialTouchPosition, Screen.width * joystickSize));
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
            joystickInitialEvent.Raise(initialTouchPosition - hwh);
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
