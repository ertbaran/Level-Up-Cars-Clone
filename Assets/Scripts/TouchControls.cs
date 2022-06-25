using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TouchControls : MonoBehaviour
{
    public Vector2 MoveValue { get; private set; }
    public bool Touched { get; private set; }

    public void OnTouchPosition(InputAction.CallbackContext value)
    {
        MoveValue = value.ReadValue<Vector2>();
    }

    public void OnPrimaryTouch(InputAction.CallbackContext value)
    {
        Touched = value.control.IsPressed();
    }
}