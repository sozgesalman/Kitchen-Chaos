using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerMovementActions playerMovementActions;

    private void Awake()
    {
        playerMovementActions = new PlayerMovementActions();
        playerMovementActions.Player.Enable();
    }

    public Vector2 GameMovmentVectorNormalized()
    {
        Vector2 inputVector = playerMovementActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
