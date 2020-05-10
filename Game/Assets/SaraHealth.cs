using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraHealth : MonoBehaviour
{
    private int maxHealth = 1;
    private int currentHealth;    
    private HealthBar healthBar;    

    // Start is called before the first frame update
    void Start() {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        //currentHealth = 50;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Damage function
    public void TakeDamage (int damage) {
        /* Deduct health to current health */
        currentHealth = currentHealth - damage;
        /* Update the health bar with then current health */
        healthBar.SetHealth(currentHealth);
    }

    public int getCurrentHealth() {
        return currentHealth;
    }

    public void gainHealth (int health) {
        /* Add health to current health */
        currentHealth = Mathf.Min(maxHealth,currentHealth + health);
        /* Update the health bar with then current health */
        healthBar.SetHealth(currentHealth);
    }
    
}
