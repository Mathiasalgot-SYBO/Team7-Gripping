using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2Event movementEvent;
    public BoolEvent actionEvent;


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
        }
        if (context.started)
        {
            actionEvent.Raise(false);
        }
    }
}
