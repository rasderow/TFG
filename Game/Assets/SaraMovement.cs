﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float x = 0f;
    private float y = 0f;
    private Animator animator;

    Vector2 movement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update() {
        // Input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // Movement
        movement.x = x;
        movement.y = y;

        // Speed animator
        animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(x), Mathf.Abs(y)) * moveSpeed);
    }

    void FixedUpdate() {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotation
        if (x!=0 || y!=0) {            
            rb.rotation = RotateCharacter(x, y);            
        }           
    }

    float RotateCharacter(float x, float y) {
        if (x == 1 && y == 1) return 180f;
        if (x == 0 && y == 1) return 225f;
        if (x == -1 && y == 1) return 270f;
        if (x == -1 && y == 0) return 315f;        
        if (x == 0 && y == -1) return 45f;
        if (x == 1 && y == -1) return 90f;
        if (x == 1 && y == 0) return 135f;        
        return 0f;
    }
}
