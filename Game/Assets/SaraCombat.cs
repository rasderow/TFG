using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraCombat : MonoBehaviour
{
    private LayerMask enemyLayer;
    private Animator animator;
    private Rigidbody2D rb;
    private SaraWeapons saraWeapons;
    private Weapon weapon;
    private Transform attackPoint;
    private Vector2 mousePosition;

    public Camera cam;
    
    // Start is called before the first frame update
    void Start() {
        enemyLayer = LayerMask.GetMask("Enemies");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        saraWeapons = GetComponent<SaraWeapons>();
        attackPoint = GameObject.FindGameObjectWithTag("SaraAttackPoint").transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetMouseButtonDown(0)) {
            // Turn Sara to mouse position direction
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);                        
            Attack();
        }
    }

    void Attack() {
        //Rotate Sara
        rb.rotation = 95 + Mathf.Atan2(mousePosition.y - rb.position.y, mousePosition.x - rb.position.x) * Mathf.Rad2Deg;                
        
        // Take the actual weapon
        weapon = saraWeapons.actualWeapon;
        Debug.Log("Arma actual: " + weapon.GetName());

        if (weapon.GetId() == 1) {
            // Start attack animation
            animator.SetTrigger("Attack");

            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, weapon.GetRange(), enemyLayer);

            // Make damage to each enemy
            foreach (Collider2D enemy in hitEnemies) {
                enemy.GetComponent<ZombieController>().TakeDamage(weapon.GetDamage());
            }
        }

        else {
            if (weapon.GetShots() > 0) {
                // Start attack animation
                animator.SetTrigger("Attack");
                weapon.Shoot();
                Debug.Log("Bales restants: " + weapon.GetShots());
                RaycastHit2D hitEnemy = Physics2D.Raycast(attackPoint.position, new Vector2(mousePosition.x - attackPoint.position.x, mousePosition.y - attackPoint.position.y), weapon.GetRange(), enemyLayer);

                if (hitEnemy) {
                    // Make damage to enemy
                    Debug.Log("He tocat a : " + hitEnemy.collider.name);
                    hitEnemy.collider.GetComponent<ZombieController>().TakeDamage(weapon.GetDamage());
                }                
            }
        }
        
    }

    void OnDrawGizmosSelected() {

        if (attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, weapon.GetRange());
    } 
    
}
