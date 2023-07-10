using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //* to change the below variable from the editor for testing if so we need to make it SerializeField unless makeing changes out side the class
    [SerializeField]
    private float moveSpeed = 1f;
    private void Update() {
        //! we need to use multiple if not if and else if because the ability to move diagonally like pressing W and D at a time
        Vector2 inputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W)) {
        inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
        inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
        inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A)) {
        inputVector.x = -1;
        }
        //! actually we need to deal with x and z not x and y but for future refactoring for this code we will separate the IO from player controller
        //transform.position += (Vector3)inputVector;
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x,0,inputVector.y);
        //! to make specific statement frame rate independent we need to multiply by Time.deltaTime or using FixedUpdate as an alternative for Update
        transform.position +=moveDir*moveSpeed*Time.deltaTime;
    }
}
