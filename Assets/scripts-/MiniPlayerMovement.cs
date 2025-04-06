using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    //public float jumpPower = 1f;
    
    private Rigidbody rb;
    //private bool canJump = false; // ジャンプ可能かどうかを管理
    public Camera miniCamera;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        miniCamera = Camera.main;
    }
    
    private void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W)) verticalInput += 1;
        if (Input.GetKey(KeyCode.S)) verticalInput -= 1;
        if (Input.GetKey(KeyCode.A)) horizontalInput -= 1;
        if (Input.GetKey(KeyCode.D)) horizontalInput += 1;
        
        // ジャンプ処理

        Vector3 forward = miniCamera.transform.forward;
        Vector3 right = miniCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * verticalInput + right * horizontalInput;
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }
}