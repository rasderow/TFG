using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraCombat : MonoBehaviour
{
    private float attackRange = 0.7f;
    private LayerMask enemyLayer;
    private Animator animator;   
    private Transform attackPoint;

    public int damage = 20;
    
    // Start is called before the first frame update
    void Start() {
        enemyLayer = LayerMask.GetMask("Enemies");
        animator = GetComponent<Animator>();
        attackPoint = GameObject.FindGameObjectWithTag("SaraAttackPoint").transform;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
        
    }

    void Attack() {
        // Start attack animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        // Make damage to each enemy
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<ZombieController>().TakeDamage(damage);
            Debug.Log("Sara: I hit " + enemy.name + " and I make " + damage + " damage point to it");
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
