using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Rigidbody2D rb;    
    private Transform target;
    private float initialRotation = 90f;
    private float nextAttackTime = 0f;
    private LayerMask saraLayer;
    private int currentHealth;

    public Animator animator;
    public Transform attackPoint;
    public float speed;
    public float visionRange;
    public float attackRange;  
    public int damage; 
    public float attackRate; // Number of attacks per second
    public int maxHealth = 100;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();        
        target = GameObject.FindGameObjectWithTag("Sara").GetComponent<Transform>();
        saraLayer = LayerMask.GetMask("Sara");
        currentHealth = maxHealth;
        visionRange = 30f;
    }
        
    void Update() {

        if (currentHealth <= 0) {            
            return;            
        }

        // Distance between Zombie and Sara
        float targetDistance = Vector2.Distance(target.position, transform.position);

        // Detect the colision with Sara
        Collider2D hitSara = Physics2D.OverlapCircle(attackPoint.position, attackRange, saraLayer);

        // If the zombie can see Sara, then it move to her
        if (targetDistance <= visionRange && hitSara == null) {
            // Spin the sprite for orient it to Sara
            Spin();
            // Move the zombie to new position
            Move();            
        }
        else { 
            // Zombie can not view Sara and it stop
            Stop();
        }

        // If the zombie can attack to Sara, it does it
        if (hitSara != null && Time.time >= nextAttackTime) {
            // Spin the sprite for orient it to Sara
            Spin();
            // Attack to Sara
            Attack(hitSara);
            // Update the next attack time
            nextAttackTime = Time.time + 1f / attackRate;           
        }
        else {
            animator.SetBool("Attack", false);
        }
    }
    
    void Spin() {
        // Calculate the vector between zombie and Sara
        Vector2 direction = target.position - transform.position;
        // Calculete the angle of the vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Rotate the zombie the angle
        rb.rotation = initialRotation + angle;
    }

    void Move() {
        // Animate the zombe
        animator.SetBool("Walking", true);
        //Activate the sound
        GetComponent<AudioSource>().mute = false;
        // Move to a new positon
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }    

    void Attack(Collider2D hitSara) {
        // Animate the zombe        
        animator.SetBool("Attack",true);
        //Activate the sound
        GetComponent<AudioSource>().mute = false;
        // Make damage to Sara            
        hitSara.GetComponent<SaraHealth>().TakeDamage(damage);        
    }

    void Stop() {
        // Animate the zombe        
        animator.SetBool("Walking", false);
        //Mute the sound
        GetComponent<AudioSource>().mute = true;
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage) {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0) {
            animator.SetBool("IsDead", true);
            //Mute the sound
            GetComponent<AudioSource>().mute = true;
            GetComponent<Collider2D>().enabled = false;
            GameObject.Destroy(gameObject, 10f);
        }
    }
}
