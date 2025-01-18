using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    PlayerMovementActions playerMovementActions;

    public event EventHandler OnPlayerInteract;
    private void Awake()
    {
        playerMovementActions = new PlayerMovementActions();
        playerMovementActions.Player.Enable();   
        playerMovementActions.Player.Interact.performed += Interact_Performed;

    }

    private void Interact_Performed(InputAction.CallbackContext obj)
    {
        OnPlayerInteract?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GameMovmentVectorNormalized()
    {
        Vector2 inputVector = playerMovementActions.Player.Move.ReadValue<Vector2>();

      

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
