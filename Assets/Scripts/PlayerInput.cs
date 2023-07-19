using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameInputActions playerInputs;
    public event EventHandler OnInteractAction;
    private void Awake() {
        //* we create global object to deal with inputActions related to player
        playerInputs = new GameInputActions();
        playerInputs.Player.Enable();
        playerInputs.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    //* we need to test the game functionalities after each refactoring before any other task or new feature
    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputs.Player.Move.ReadValue<Vector2>();
          return inputVector.normalized;
    }
}
