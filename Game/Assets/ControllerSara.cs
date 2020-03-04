using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSara : MonoBehaviour
{
    public float Speed = 2f;
    private Animator animator;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return")) {
            animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * Speed * h);
    }
}
