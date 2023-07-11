using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameInputActions playerInputs;
    private void Awake() {
        //* we create global object to deel with inputActions related to player
        playerInputs = new GameInputActions();
        playerInputs.Player.Enable();
    }
    //* we need to test the game functionalities after each refactoring before any other task or new feature
    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputs.Player.Move.ReadValue<Vector2>();
          return inputVector.normalized;
    }
}
