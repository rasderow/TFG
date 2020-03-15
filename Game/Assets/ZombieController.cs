using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private float initialRotation = 90f;
    public float visionDistance;
    public float attackDistance;
    public float moveSpeed;
    public Animator animator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update() {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float targetDistance = Vector3.Distance(target.position, transform.position);
        Debug.Log("targetDistance: " + targetDistance);

        Vector2 actualPosition = rb.transform.position;
        float actualRotation = rb.rotation;

        Debug.Log("actualPosition: " + actualPosition);
        Debug.Log("actualRotation: " + actualRotation);

        animator.SetBool("Walking", false);
        if (targetDistance < visionDistance) {
            rb.rotation = initialRotation + angle;
            if (attackDistance < targetDistance) {
                animator.SetBool("Walking", true);
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            }
        }

        else {
            rb.rotation = actualRotation;
            rb.MovePosition(actualPosition);
        }

        /*if (attackDistance < targetDistance && targetDistance <= visionDistance) {
            animator.SetBool("Walking", true);
            rb.rotation = initialRotation + angle;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                        
        }

        else {
            animator.SetBool("Walking", false);
            if ()
            rb.rotation = initialRotation + angle;
        }*/
        





        

        /*if 

        
        /*Debug.Log("direction: " + direction);
        Debug.Log("angle: " + angle);*/
    }
}
