using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
    [SerializeField]
    private PlayerInput playerInput;
    private bool isWalking;
    //* To change the below variable from the editor for testing if so we need to make it SerializeField unless makeing changes out side the class
    private float moveSpeed = 7f;
    private void Update() {
        //! We need to use multiple if not if and else if because the ability to move diagonally like pressing W and D at a time
        //! Actually we need to deal with x and z not x and y but for future refactoring for this code we will separate the IO from player controller
        //Transform.position += (Vector3)inputVector;
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.5f;
        float playerHeight = 2f;
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x,0,inputVector.y);
        //! To make specific statement frame rate independent we need to multiply by Time.deltaTime or using FixedUpdate as an alternative for Update
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position+playerHeight*Vector3.up,playerRadius,moveDir,moveDistance);
        if (!canMove) {
        Vector3 moveDirX = new Vector3(moveDir.x,0,0).normalized;
        canMove = !Physics.CapsuleCast(transform.position,transform.position+playerHeight*Vector3.up,playerRadius,moveDirX,moveDistance);
            if (canMove) {
                moveDir = moveDirX;
            }
            else {
                Vector3 moveDirZ = new Vector3(0,0,moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position,transform.position+playerHeight*Vector3.up,playerRadius,moveDirZ,moveDistance);
                if (canMove) {
                    moveDir = moveDirZ;
                }
                else { 
                    // we tried to make the player move right or left when the gamer attempt to move diagonally when collide 
                }
            }
        }
        if(canMove){
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        float rotationSpeed = 20f;
        //! we need to make the player look at the direction as same as the moveDir but sequentionally or animated with same initial and final speed as the rotationSpeed
        //! To do so we are  using Vector3.Lerp or slerp 
        transform.forward = Vector3.Slerp(transform.forward,moveDir,rotationSpeed*Time.deltaTime);
    }
   public bool IsWalking() {
        return isWalking;
    }
}
