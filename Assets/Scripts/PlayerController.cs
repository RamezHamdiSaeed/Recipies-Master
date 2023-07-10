using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
       Vector3 newPosition = transform.position + moveSpeed * Time.deltaTime * new Vector3(horizontalMove,0,verticalMove);
        transform.position = newPosition;
    }
}
