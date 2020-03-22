using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;    
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start() {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Damage function
    public void TakeDamage (int damage) {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);
    }
}
