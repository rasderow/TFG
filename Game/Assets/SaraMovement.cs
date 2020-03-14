using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float x = 0f;
    public float y = 0f;
    public Animator animator;

    Vector2 movement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // Movment
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
            //transform.Rotate(0,0,90f);
            rb.rotation = RotateCharacter(x, y);            
        }

        


    }

    float RotateCharacter(float x, float y) {
        if (x == 1 && y == 1) return 180f;
        if (x == 0 && y == 1) return 225f;
        if (x == -1 && y == 1) return 270f;
        if (x == -1 && y == 0) return 315f;
        //if (x == -1 && y == -1) return 360f;
        if (x == 0 && y == -1) return 45f;
        if (x == 1 && y == -1) return 90f;
        if (x == 1 && y == 0) return 135f;        
        return 0f;
    }
}
