using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour,IKitchenObjectParent {
    //! make this script a singleton to be accessible from any script in the project without reference it again and again and again
    public static Player Instance { get;private set; }
    public event EventHandler<OnSelectedClearCounterChangedEventArgs> OnSelectedClearCounterChanged;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform kitchenObjectHandHeld;
    private bool isWalking;
    private readonly float moveSpeed = 7f;
    private KitchenObject kitchenObject;

    // to give us the ability to interact to counters without walking we need to use the below variable when the io returned with (0,0)
    private Vector3 lastInteract;
    private BaseCounter selectedCounter;
    public class OnSelectedClearCounterChangedEventArgs : EventArgs {
    public  BaseCounter selectedCounter;
    }
    private void Awake() {
        if (Instance != null) Debug.LogError("There is more than single instance");
        Instance = this;
    }
    private void Start() {
        playerInput.OnInteractAction += PlayerInput_OnInteractAction;
    }

    private void PlayerInput_OnInteractAction(object sender, System.EventArgs e) {
        if (selectedCounter != null) {
            selectedCounter.Interact(this);
        }
    }

    private void Update() {
     HandleMovement();
     HandleLastInteract();
    }
    private void HandleLastInteract() {
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteract, out RaycastHit counter, interactDistance, layerMask)) {
            if (counter.transform.TryGetComponent<BaseCounter>(out BaseCounter baseCounter)) {
                if (selectedCounter != baseCounter) SetSelectedCounter(baseCounter);
            }
            else SetSelectedCounter(null);
        }
        else {
            SetSelectedCounter(null);
        }
        if(moveDir != Vector3.zero)        lastInteract = moveDir;
    }
    private void HandleMovement() {
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.5f;
        float playerHeight = 2f;
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + playerHeight * Vector3.up, playerRadius, moveDir, moveDistance);
        if (!canMove) {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + playerHeight * Vector3.up, playerRadius, moveDirX, moveDistance);
            if (canMove) {
                moveDir = moveDirX;
            }
            else {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + playerHeight * Vector3.up, playerRadius, moveDirZ, moveDistance);
                if (canMove) {
                    moveDir = moveDirZ;
                }
            }
        }
        if (canMove) {
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        float rotationSpeed = 20f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }
   public bool IsWalking() {
        return isWalking;
    }
    private void SetSelectedCounter(BaseCounter selectedCounter) {
        this.selectedCounter = selectedCounter;
        OnSelectedClearCounterChanged?.Invoke(this, new OnSelectedClearCounterChangedEventArgs
        {
            selectedCounter = this.selectedCounter
        });
    }
    public Transform GetKitchenObjectFollowTransform() {
        return kitchenObjectHandHeld;
    }
    public KitchenObject GetKitchenObject() { return kitchenObject; }
    public void ClearKitchenObjectInParent() {
        kitchenObject = null;
    }
    public bool HasKitchenObjectInParent() {
        return kitchenObject != null;
    }
    public void SetKitchenObjectInParent(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }
}
