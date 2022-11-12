using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 6f;
    public float movementMultipler = 10f;
    float hortizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;
    float rbDrag = 6f;

    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update(){
        MyInput();
        ControlDrag();
    }

    void MyInput(){
        hortizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * hortizontalMovement;
    }

    void ControlDrag(){
        rb.drag = rbDrag;
    }

    private void FixedUpdate(){
        MovePlayer();
    }

    void MovePlayer(){
        rb.AddForce(moveDirection.normalized * movementSpeed * movementMultipler, ForceMode.Acceleration);
    }
}
