using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    private float initialRotation = 90f;

    public Animator animator;
    public float speed;
    public float visionDistance;
    public float attackDistance;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Sara").GetComponent<Transform>();
        
    }

    void Update() {
        // Distance between Zombie and Sara
        float targetDistance = Vector2.Distance(target.position, transform.position);

        // If Zombie can see Sara, then it move to her
        if (targetDistance < visionDistance && attackDistance < targetDistance)
        { 
            // Calculate the vector between zombie and Sara
            Vector2 direction = target.position - transform.position;
            // Calculete the angle of the vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // Rotate the zombie the angle
            rb.rotation = initialRotation + angle;
            // Activate the walking animation
            setAnimatorParameters(false, true);
            // Move the zombie to new position
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else {
            // If Zombie is a distance to Sara less than attackDistance, attack her.
            if (targetDistance < attackDistance) {                
                setAnimatorParameters(true, false);
            }

            // Zombie is stopped
            else {                
                setAnimatorParameters(false, false);
                Debug.Log("targetDistance: " + targetDistance);
            }            
        }        
    }

    void setAnimatorParameters(bool attack, bool walking) {
        animator.SetBool("Attack", attack);
        animator.SetBool("Walking", walking);
    }


}
